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
    //recorded buttons 
    [Header( "Recorded Inputs" )]
    [Tooltip( "Button names (from Input manager) that should be recorded" )]
    [SerializeField]
    List<string> recordedButtons = new List<string>();
    //recorded axes
    [Tooltip( "Axis names (from Input manager) that should be recorded" )]
    [SerializeField]
    List<string> recordedAxes = new List<string>();

    //recorded keycodes
    [Tooltip( "Key buttons that should be recorded" )]
    [SerializeField]
    List<KeyCode> recordedKeys = new List<KeyCode>();

    //recorded mouse events
    [Tooltip( "Whether mouse position/button states should be recorded each frame (mouse axes are separate from this)" )]
    public bool recordMouseEvents;

    public InputTASKMode mode_ = InputTASKMode.Passthru;
    public bool isPaused{get; set;}

    public InputTASKMode Mode
    {
        get{ return mode_; }
        set
        {
            mode_ = value;
            // if ( mode_ == InputTASKMode.Playback )
            // {
            //     //start playback
            //     StartCoroutine( Playback() );
            // }
            // else if ( mode_ == InputTASKMode.Recording )
            // {
            //     //start recording
            //     StartCoroutine( Recording() );
            // }
            // else if ( mode_ == InputTASKMode.Passthru )
            // {
            //     //passthrough
            //     StartCoroutine( Passthru() );
            // }
        }
    }
    //recording functions

    public Recording  currRecording;



    // mouse axes and buttons
    private const string _MOUSE_POS_X_ID = "MOUSE_POSITION_X";
    private const string _MOUSE_POS_Y_ID = "MOUSE_POSITION_Y";
    private const string _MOUSE_BUTTON_ID = "MOUSE_BUTTON_";

    // mouse functions

    

}
