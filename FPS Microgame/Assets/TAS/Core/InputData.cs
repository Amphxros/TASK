using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct InputObject{
    public string key;
    public int mMinutes_;
    public int mSeconds_;

}


public class InputData : MonoBehaviour
{
    float mTime_ = 0;
    int mMinutes_ = 0;  // num minutes
    int mSeconds_ = 0;  //num secs
    bool newInput = false;
    InputObject[] inputs;

    public InputObject getKeyboardInput() {
        InputObject obj;

        obj.key = Input.inputString;
        obj.mMinutes_ = mMinutes_;
        obj.mSeconds_ = mSeconds_;

        return obj;
    }

    //CAMBIAR ESTO??
    public InputObject getMouseInput() {
        InputObject obj;

        obj.key = Input.inputString;
        obj.mMinutes_ = mMinutes_;
        obj.mSeconds_ = mSeconds_;

        return obj;
    }

    //Y ESTO MAYBE
    public InputObject getGamePadInput() {
        InputObject obj;

        obj.key = Input.inputString;
        obj.mMinutes_ = mMinutes_;
        obj.mSeconds_ = mSeconds_;

        return obj;
    }

    public InputObject[] getInputs() {
        
        Debug.Log(Input.inputString);
        int numInputs = Input.inputString.Length;
        inputs = new InputObject[numInputs];

        int i = 0;

        foreach (char c in Input.inputString) {
            InputObject obj;

            obj.key = c.ToString();
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            inputs[i] = obj;
            i++;
        }

        return inputs;
    }

    void compruebaInput() {
        if (Input.GetKeyDown(KeyCode.W))
        {
            InputObject obj;

            obj.key = "w";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            Debug.Log("he llegado");
        }
    }
    void Update()
    {
        
        if(Time.time - mTime_ <=60){
            mMinutes_++;
            mTime_=Time.time;
            mSeconds_=0;
        } 
        else{
            mSeconds_=(int)(Time.time - mTime_);
        }

        compruebaInput();
        
    }

    public bool getNew() {
        return newInput;
    }

}
