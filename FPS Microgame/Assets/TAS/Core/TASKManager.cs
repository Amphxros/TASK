using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    List<KeyCode> _recordedKeys = new List<KeyCode>();

    //recorded mouse events
    [Tooltip( "Whether mouse position/button states should be recorded each frame (mouse axes are separate from this)" )]
    public bool recordMouseEvents;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
