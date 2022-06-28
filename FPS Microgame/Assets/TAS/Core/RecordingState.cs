using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordingState
{
    public readonly Recording targetRecording;
    public float Time { get; private set;}
    public int FrameIdx { get; private set; }
    public RecordingState( Recording recording ) {
        targetRecording = recording;
    }

    public void SkipToTime( float newTime ) {
        this.Time = Mathf.Clamp( newTime, 0, targetRecording.Length );
        this.FrameIdx = targetRecording.GetFrameForTime( Time );
    }
    public void AdvanceByTime( float deltaTime ) {
        this.Time += deltaTime;
        this.FrameIdx = targetRecording.GetFrameForTime( Time );
    }
    public void AppendNewRecordingFrame( float deltaTime ) {
        this.Time += deltaTime;
        targetRecording.AddFrame( this.Time );
        this.FrameIdx = targetRecording.FrameCount - 1;
    }
    public void AddInputToCurrentFrame( Recording.InputState inputState ) {
        targetRecording.AddInput( this.FrameIdx, inputState );
    }
    public void AddPropertyToCurrentFrame( Recording.FrameProperty frameProperty ) {
        targetRecording.AddProperty( this.FrameIdx, frameProperty );
    }
    public void ClearRecordingAfterCurrentTime() {
        targetRecording.ClearFrames( this.FrameIdx );
    }

}