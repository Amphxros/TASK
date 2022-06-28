using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  public enum InputTASKMode {
        Passthru,   // normal input
        Record,     // normal input & record it
        Playback   // all input comes from recording
    }
public class TASKManager : MonoBehaviour
{
 #region Inspector properties
        [Header( "Recorded Inputs" )]
        [Tooltip( "Button names (from Input manager) that should be recorded" )]
        [SerializeField]
        List<string> _recordedButtons = new List<string>();

        [Tooltip( "Axis names (from Input manager) that should be recorded" )]
        [SerializeField]
        List<string> _recordedAxes = new List<string>();

        [Tooltip( "Key buttons that should be recorded" )]
        [SerializeField]
        List<KeyCode> _recordedKeys = new List<KeyCode>();

        [Tooltip( "Whether mouse position/button states should be recorded each frame (mouse axes are separate from this)" )]
        public bool recordMouseEvents;

        [SerializeField]
        [HideInInspector]
        private InputTASKMode _mode = InputTASKMode.Passthru; // initial mode that vcr is operating in
        /// <summary>
        /// Is this VCR:
        /// - Recording: Taking live input and writing to a Recording and passing it on to callers
        /// - Playback: Replaying input from a previous Recording
        /// - Passthrough: Taking live input and passing on to callers
        /// </summary>
        public InputTASKMode Mode {
            get { return _mode; }
            private set { _mode = value; }
        }

        /// <summary>
        /// Whether current playback or recording is paused. If there is no current recording or playback, Input is not affected
        /// </summary>
        /// <value></value>
        public bool IsPaused { get; set; }
        #endregion

        /// <summary>
        /// Holds info about the playback/record state. eg: playback time
        /// </summary>
        RecordingState recordingState = new RecordingState( new Recording() );     // the recording currently in the VCR. Copy or ToString() this to save.
        public Recording CurrentRecording => recordingState.targetRecording;
        public float CurrentPlaybackTime {
            get {
                return recordingState.Time;
            }
            set {
                recordingState.SkipToTime( value );
                if ( Mode == InputTASKMode.Record ) {
                    // wipe any recording after current time
                    recordingState.targetRecording.ClearFrames( recordingState.FrameIdx );
                }
            }
        }

        Queue<Recording.FrameProperty> nextPropertiesToRecord = new Queue<Recording.FrameProperty>();   // if SyncLocation or SyncProperty are called, this will hold their results until the recordstring is next written to

        Dictionary<string, Recording.InputState> lastFrameInputs = new Dictionary<string, Recording.InputState>();    // list of inputs from last frame (for seeing what buttons have changed state)
        Dictionary<string, Recording.InputState> thisFrameInputs = new Dictionary<string, Recording.InputState>();
        Dictionary<string, Recording.FrameProperty> thisFrameProperties = new Dictionary<string, Recording.FrameProperty>();

        public event System.Action finishedPlayback;    // sent when playback finishes

        /// <summary>
        /// Start recording. Will append to current Recording, wiping all data after current playback time
        /// </summary>
        public void Record() {
            Record( forceNewRecording: false );
        }

        /// <summary>
        /// Start recording onto the provided Recording. Any frames after the given startRecordingFromTime will be wiped
        /// </summary>
        /// <param name="appendRecording"></param>
        /// <param name="startRecordingFromTime"></param>
        public void Record( Recording appendRecording, float startRecordingFromTime ) {
            recordingState = new RecordingState( appendRecording );
            recordingState.SkipToTime( startRecordingFromTime );

            Record( forceNewRecording: false );
        }

        /// <summary>
        /// Start recording, any current Recording will be wiped and a new recording begun
        /// </summary>
        public void RecordNew() {
            Record( forceNewRecording: true );
        }

        void Record( bool forceNewRecording ) {
            if ( forceNewRecording ) {
                recordingState = new RecordingState( new Recording() );
                nextPropertiesToRecord.Clear();
            }
            else {
                recordingState.targetRecording.ClearFrames( recordingState.FrameIdx + 1 );
            }

            Mode = InputTASKMode.Record;
            IsPaused = false;
            ClearInput();
        }

        /// <summary>
        /// Start or resume playing back the current Recording, if present.
        /// </summary>
        public void Play() {
            if ( Mode != InputTASKMode.Playback ) {
                ClearInput(); // dont' clear if just resuming playback
                Mode = InputTASKMode.Playback;
            }
            IsPaused = false;
        }

        /// <summary>
        /// Play the specified Recording, from optional specified time
        /// </summary>
        /// <param name='recording'>
        /// Recording.
        /// </param>
        /// <param name='startPlaybackFromTime'>
        /// </param>
        public void Play( Recording recording, float startPlaybackFromTime = 0 ) {
            recordingState = new RecordingState( recording );
            recordingState.SkipToTime( startPlaybackFromTime );

            ClearInput();

            Mode = InputTASKMode.Playback;
        }

        /// <summary>
        /// Pause recording or playback
        /// </summary>
        public void Pause() {
            IsPaused = true;
        }

        /// <summary>
        /// Set the current recording's (if present) playback time to the beginning
        /// </summary>
        public void RewindToStart() {
            if ( Mode == InputTASKMode.Record )
                Stop();
            CurrentPlaybackTime = 0;
        }

        /// <summary>
        /// Stop recording or playback. Live input will be passed through
        /// </summary>
        public void Stop() {
            Mode = InputTASKMode.Passthru;
            ClearInput();
        }

        /// <summary>
        /// Stop playback or recording, if present, and load a recording
        /// </summary>
        /// <param name="newRecording"></param>
        public void LoadRecording( Recording newRecording ) {
            Stop();
            recordingState = new RecordingState( newRecording );
        }

        /// <summary>
        /// Adds a custom property to the recording, so you can sync other (non-input) events as well.
        /// eg: doors opening, enemy spawning, etc
        /// </summary>
        /// <param name='propertyName'>
        /// Property name.
        /// </param>
        /// <param name='propertyValue'>
        /// Property value.
        /// </param>
        public void SaveProperty( string propertyName, string propertyValue ) {
            // duplicates dealt with when recorded
            var frameProp = new Recording.FrameProperty( propertyName, propertyValue );
            if ( !nextPropertiesToRecord.Contains( frameProp ) )
                nextPropertiesToRecord.Enqueue( frameProp );
        }

        #region Recording & Playback
        void Update() {
            if ( IsPaused )
                return;

            if ( Mode == InputTASKMode.Playback ) {
                AdvancePlayback( Time.deltaTime );
            }
            else if ( Mode == InputTASKMode.Record ) {
                RecordCurrentFrame();
            }
        }

        List<Recording.InputState> _inputStateCache = new List<Recording.InputState>();
        List<Recording.FrameProperty> _propCache = new List<Recording.FrameProperty>();
        void AdvancePlayback( float delta ) {
            int lastFrameIdx = recordingState.FrameIdx;
            recordingState.AdvanceByTime( delta );
            if ( recordingState.Time > recordingState.targetRecording.Length ) {
                // reached end of recording
                finishedPlayback?.Invoke();
                Stop();
                return;
            }

            if ( recordingState.FrameIdx == lastFrameIdx )
                return; // no new playback data TODO clear deltas if saved

            // duplicate this input to previous frame
            lastFrameInputs.Clear();
            foreach ( var input in thisFrameInputs ) {
                lastFrameInputs[input.Key] = input.Value;
            }

            // update inputs with changes from each playback frame since last real frame
            for ( int checkFrame = lastFrameIdx + 1; checkFrame <= recordingState.FrameIdx; checkFrame++ ) {
                // Inputs
                _inputStateCache.Clear();
                recordingState.targetRecording.GetInputs( checkFrame, _inputStateCache );
                foreach ( var input in _inputStateCache ) {
                    // if a button was pressed and released within a single playback frame, key up/down flags could be missed
                    // TODO fix by either using events to signal key up/downs (not ideal) or buffering up/downs over subsequent frames (less ideal)
                    thisFrameInputs[input.inputId] = input;
                }

                // Properties
                _propCache.Clear();
                recordingState.targetRecording.GetProperties( checkFrame, _propCache );
                foreach ( var prop in _propCache ) {
                    thisFrameProperties[prop.name] = prop;
                }
            }
        }

        void RecordCurrentFrame() {
            recordingState.AppendNewRecordingFrame( Time.deltaTime );

            // mouse
            if ( recordMouseEvents ) {
                recordingState.AddInputToCurrentFrame( new Recording.InputState( GetMouseButtonId( 0 ), Input.GetMouseButton( 0 ) ) );
                recordingState.AddInputToCurrentFrame( new Recording.InputState( GetMouseButtonId( 1 ), Input.GetMouseButton( 1 ) ) );
                recordingState.AddInputToCurrentFrame( new Recording.InputState( GetMouseButtonId( 2 ), Input.GetMouseButton( 2 ) ) );
                recordingState.AddInputToCurrentFrame( new Recording.InputState( _MOUSE_POS_X_ID, Input.mousePosition.x ) );
                recordingState.AddInputToCurrentFrame( new Recording.InputState( _MOUSE_POS_Y_ID, Input.mousePosition.y ) );
            }

            // buttons
            foreach ( var buttonName in _recordedButtons ) {
                recordingState.AddInputToCurrentFrame( new Recording.InputState( buttonName, Input.GetButton( buttonName ) ) );
            }

            // axes
            foreach ( var axisName in _recordedAxes ) {
                recordingState.AddInputToCurrentFrame( new Recording.InputState( axisName, Input.GetAxis( axisName ) ) );
            }

            // keys
            foreach ( var keyCode in _recordedKeys ) {
                recordingState.AddInputToCurrentFrame( new Recording.InputState( GetKeyCodeId( keyCode ), Input.GetKey( keyCode ) ) );
            }

            // properties
            while ( nextPropertiesToRecord.Count > 0 ) {
                recordingState.AddPropertyToCurrentFrame( nextPropertiesToRecord.Dequeue() );
            }
        }


        #endregion
        /// <summary>
        /// Wipe current playback data
        /// </summary>
        void ClearInput() {
            thisFrameInputs.Clear();
            lastFrameInputs.Clear();
            thisFrameProperties.Clear();
        }

        // These methods replace those in Input, so that this object can ignore whether it is record
        #region Input replacements
        public bool GetKey( KeyCode key ) => GetKey( GetKeyCodeId( key ) );

        public bool GetKey( string keyName ) {
            if ( Mode == InputTASKMode.Playback ) {
                return thisFrameInputs.TryGetValue( keyName, out Recording.InputState thisFrameState ) && thisFrameState.buttonState;
            }

            return Input.GetKey( keyName );
        }

        public bool GetKeyDown( KeyCode key ) => GetKeyDown( GetKeyCodeId( key ) );
        public bool GetKeyDown( string keyName ) {
            if ( Mode == InputTASKMode.Playback ) {
                bool lastFrameButtonDown = lastFrameInputs.TryGetValue( keyName, out Recording.InputState lastFrameState ) && lastFrameState.buttonState;
                bool thisFrameButtonDown = thisFrameInputs.TryGetValue( keyName, out Recording.InputState thisFrameState ) && thisFrameState.buttonState;
                return thisFrameButtonDown && !lastFrameButtonDown;
            }

            return Input.GetKeyDown( keyName );
        }

        public bool GetKeyUp( KeyCode key ) => GetKeyUp( GetKeyCodeId( key ) );
        public bool GetKeyUp( string keyName ) {
            if ( Mode == InputTASKMode.Playback ) {
                bool lastFrameButtonDown = lastFrameInputs.TryGetValue( keyName, out Recording.InputState lastFrameState ) && lastFrameState.buttonState;
                bool thisFrameButtonDown = thisFrameInputs.TryGetValue( keyName, out Recording.InputState thisFrameState ) && thisFrameState.buttonState;
                return !thisFrameButtonDown && lastFrameButtonDown;
            }

            return Input.GetKeyUp( keyName );
        }

        public bool GetButton( string buttonName ) {
            if ( Mode == InputTASKMode.Playback ) {
                return thisFrameInputs.TryGetValue( buttonName, out Recording.InputState thisFrameState ) && thisFrameState.buttonState;
            }

            return Input.GetButton( buttonName );
        }

        public bool GetButtonDown( string buttonName ) {
            if ( Mode == InputTASKMode.Playback ) {
                bool lastFrameButtonDown = lastFrameInputs.TryGetValue( buttonName, out Recording.InputState lastFrameState ) && lastFrameState.buttonState;
                bool thisFrameButtonDown = thisFrameInputs.TryGetValue( buttonName, out Recording.InputState thisFrameState ) && thisFrameState.buttonState;
                return thisFrameButtonDown && !lastFrameButtonDown;
            }

            return Input.GetButtonDown( buttonName );
        }

        public bool GetButtonUp( string buttonName ) {
            if ( Mode == InputTASKMode.Playback ) {
                bool lastFrameButtonDown = lastFrameInputs.TryGetValue( buttonName, out Recording.InputState lastFrameState ) && lastFrameState.buttonState;
                bool thisFrameButtonDown = thisFrameInputs.TryGetValue( buttonName, out Recording.InputState thisFrameState ) && thisFrameState.buttonState;
                return !thisFrameButtonDown && lastFrameButtonDown;
            }

            return Input.GetButtonUp( buttonName );
        }

        public float GetAxis( string axisName ) {
            if ( Mode == InputTASKMode.Playback ) {
                if ( thisFrameInputs.TryGetValue( axisName, out Recording.InputState thisFrameState ) )
                    return thisFrameState.axisValue;
                else
                    return 0;
            }

            return Input.GetAxis( axisName );
        }
        
        public float GetAxisRaw( string axisName ) {
            if ( Mode == InputTASKMode.Playback ) {
                if ( thisFrameInputs.TryGetValue( axisName, out Recording.InputState thisFrameState ) )
                    return thisFrameState.axisValue;
                else
                    return 0;
            }

            return Input.GetAxisRaw( axisName );
        }

        public bool GetMouseButton( int buttonNum ) {
            if ( Mode == InputTASKMode.Playback ) {
                return thisFrameInputs.TryGetValue( GetMouseButtonId( buttonNum ), out Recording.InputState thisFrameState ) && thisFrameState.buttonState;
            }

            return Input.GetMouseButton( buttonNum );
        }

        public bool GetMouseButtonDown( int buttonNum ) {
            if ( Mode == InputTASKMode.Playback ) {
                string buttonId = GetMouseButtonId( buttonNum );
                bool lastFrameButtonDown = lastFrameInputs.TryGetValue( buttonId, out Recording.InputState lastFrameState ) && lastFrameState.buttonState;
                bool thisFrameButtonDown = thisFrameInputs.TryGetValue( buttonId, out Recording.InputState thisFrameState ) && thisFrameState.buttonState;
                return thisFrameButtonDown && !lastFrameButtonDown;
            }

            return Input.GetMouseButtonDown( buttonNum );
        }

        public bool GetMouseButtonUp( int buttonNum ) {
            if ( Mode == InputTASKMode.Playback ) {
                string buttonId = GetMouseButtonId( buttonNum );
                bool lastFrameButtonDown = lastFrameInputs.TryGetValue( buttonId, out Recording.InputState lastFrameState ) && lastFrameState.buttonState;
                bool thisFrameButtonDown = thisFrameInputs.TryGetValue( buttonId, out Recording.InputState thisFrameState ) && thisFrameState.buttonState;
                return !thisFrameButtonDown && lastFrameButtonDown;
            }

            return Input.GetMouseButtonUp( buttonNum );
        }

        public Vector3 mousePosition {
            get {
                if ( Mode == InputTASKMode.Playback ) {
                    float mouseX = thisFrameInputs.TryGetValue( _MOUSE_POS_X_ID, out Recording.InputState thisFrameXState ) ? thisFrameXState.axisValue : 0;
                    float mouseY = thisFrameInputs.TryGetValue( _MOUSE_POS_Y_ID, out Recording.InputState thisFrameYState ) ? thisFrameYState.axisValue : 0;
                    return new Vector3( mouseX, mouseY, 0 );
                }

                return Input.mousePosition;
            }
        }

        public bool TryGetProperty( string propertyName, out string propertyValue ) {
            if ( thisFrameProperties.TryGetValue( propertyName, out Recording.FrameProperty frameProp ) ) {
                propertyValue = frameProp.value;
                return true;
            }
            else {
                propertyValue = string.Empty;
                return false;
            }
        }
        #endregion

        private const string _MOUSE_POS_X_ID = "MOUSE_POSITION_X";
        private const string _MOUSE_POS_Y_ID = "MOUSE_POSITION_Y";
        private const string _MOUSE_BUTTON_ID = "MOUSE_BUTTON_";

        private static string GetMouseButtonId( int buttonNumber ) {
            return _MOUSE_BUTTON_ID + buttonNumber;
        }

        private static string GetKeyCodeId( KeyCode kc ) {
            return KeycodeHelper.GetKey( kc );
        }

        #region IO Helpers
        public void PlayRecordingFromDisk( string path, float startPlaybackFromTime = 0 ) {
            string fileString = File.ReadAllText( path );
            Recording r = new Recording( path );
            Play( r, startPlaybackFromTime );
        }

        public void WriteCurrentRecordToDisk( string path ) {
            if ( CurrentRecording == null ) {
                throw new InvalidDataException( "No record to save" );
            }

            string recordJson = CurrentRecording.ToJson();
            File.WriteAllText( path, recordJson );
        }
        #endregion
    

}
