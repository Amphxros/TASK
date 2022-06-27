using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof(TASKManager ) )]
public class InputTASKTextRecordingLoader : MonoBehaviour
{
    private TASKManager mRecorder_;

    public TextAsset mRecordingAsset_;
    public bool playRecordingOnStart;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        
    }

}
