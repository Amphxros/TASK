using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct TransformState {
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;
    public TransformState( Transform t ) {
        position = t.localPosition;
        rotation = t.localRotation;
        scale = t.localScale;
    }
}

public class TASKTransformSyncer : MonoBehaviour
{
     public TASKManager recorderToSyncTo;

        [Tooltip( "If left blank, GameObject's name will be used" )]
        public string customTag;
        public string RecordingTagPrefix => ( string.IsNullOrEmpty( customTag ) ? name : customTag ) + "_transform";

        public bool syncPosition = true;
        public bool syncRotation = true;
        public bool syncScale = true;

        void Update() {
            if ( recorderToSyncTo == null )
                return;

            if ( !syncPosition && !syncRotation && !syncScale )
                return;

            if ( recorderToSyncTo.Mode == InputTASKMode.Record ) {
                RecordTransformState();
            }
            else if ( recorderToSyncTo.Mode == InputTASKMode.Playback ) {
                MatchTransformToRecording();
            }
        }

        /// <summary>
        /// Record this transforms state to the current recording in the VCR
        /// </summary>
        void RecordTransformState() {
            TransformState currentState = new TransformState( transform );
            string stateString = JsonUtility.ToJson( currentState );

            recorderToSyncTo.SaveProperty( RecordingTagPrefix, stateString );
        }
    
      void MatchTransformToRecording() {
            if ( recorderToSyncTo.TryGetProperty( RecordingTagPrefix, out string stateString ) ) {
                TransformState recordedState = JsonUtility.FromJson<TransformState>( stateString );

                if ( syncPosition )
                    transform.localPosition = recordedState.position;

                if ( syncRotation )
                    transform.localRotation = recordedState.rotation;

                if ( syncScale )
                    transform.localScale = recordedState.scale;
            }
        }

    void recordTransform(){
        TransformState t= new TransformState(transform);
        string state= JsonUtility.ToJson(t);

    }

}