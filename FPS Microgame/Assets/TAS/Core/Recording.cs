using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class FrameProperty{
    public string name;
    public string value;

    public FrameProperty(string name, string value){
        this.name = name;
        this.value = value;
    }
}

public class InputState{
    public string input;
    public bool buttonState;
    public float axisValue;

    public InputState(string input, bool buttonState){
        this.input = input;
        this.buttonState = buttonState;
        this.axisValue = 0;
    }

    public InputState(string input, float axisValue){
        this.input = input;
        this.buttonState = false;
        this.axisValue = axisValue;
    }

    

}

public class Frame{
    public float time;
    public List<InputState> inputs = new List<InputState>();
    public List<FrameProperty> properties = new List<FrameProperty>();

    public Frame(float time){
        this.time = time;
    }
}

[Serializable]
public class Recording : ISerializationCallbackReceiver
{
     private List<Frame> frames = new List<Frame>();
    [SerializeField]
    private int _schemaVersion = _CURRENT_JSON_SCHEMA_VERSION;      // make sure schema version is in the JSON
    private const int _CURRENT_JSON_SCHEMA_VERSION = 1;
    
    public int FrameCount => frames.Count;
    public float Length => frames.Count > 0 ? frames[frames.Count - 1].time : 0;
    
    public Recording(){
       
    }
    public Recording(string jsonRecording){
        
    }
    public Recording(Recording old){
        if(old==null){
            return;
        }
        frames.AddRange(old.frames);

    }
    
    public int getFrameForTime(float time){
        if(FrameCount==0){
            return -1;
        }
        else{
            for(int i=1; i<FrameCount; i++){
                if(frames[i].time>time){
                    return i-1;
                }
            }

            return FrameCount -1;
        }
    }

    private void clearAllFrames(){
        frames.Clear();
    }
    public void clearFrames(int frame){
        if(frame>0 && frame<FrameCount){
            frames.RemoveRange(frame, FrameCount-frame);
        }
        else{
            clearAllFrames();
        }
    }

    public void addFrame(float time){
        if(FrameCount>0){
            if(time<=Length){
                return;
            }
        }

        Frame frame= new Frame(time);
        frames.Add(frame);
    }

    public void addInput(int frame, InputState input){
        
      
    }

    public void addProperty(int frame, string propertyName, string propertyValue){

    }




    public void OnBeforeSerialize()
    {
        // do nothing
    }
    public void OnAfterDeserialize()
    {
        // do nothing
    }

}
