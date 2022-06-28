using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof(TASKManager ) )]
public class InputTASKTextRecordingLoader : MonoBehaviour
{
    private TASKManager _recorder;
    public TextAsset loadRecordingOnStart;
    public bool playRecordingOnStart;


    void Start() {
        _recorder = GetComponent<TASKManager>();  
        if ( loadRecordingOnStart != null ) {
            Recording recording = new Recording( loadRecordingOnStart.text );
            _recorder.LoadRecording( recording );  
            if ( playRecordingOnStart )
                _recorder.Play();
        }
    }

}

