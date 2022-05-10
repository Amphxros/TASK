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
    
    public InputObject getKeyboardInput(){
        InputObject obj;

        obj.key=Input.inputString;
        obj.mMinutes_=mMinutes_;
        obj.mSeconds_=mSeconds_;

        return obj;
    }
    
    //CAMBIAR ESTO??
    public InputObject getMouseInput(){
         InputObject obj;

        obj.key=Input.inputString;
        obj.mMinutes_=mMinutes_;
        obj.mSeconds_=mSeconds_;

        return obj;
    }

    //Y ESTO MAYBE
    public InputObject getGamePadInput(){
        InputObject obj;

        obj.key=Input.inputString;
        obj.mMinutes_=mMinutes_;
        obj.mSeconds_=mSeconds_;

        return obj;
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
        
    }

}
