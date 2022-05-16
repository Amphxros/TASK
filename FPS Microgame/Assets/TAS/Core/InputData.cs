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

    TASManager manager;


    private void Awake()
    {
        manager = GetComponentInParent<TASManager>();
    }


    public InputObject getKeyboardInput() {
        InputObject obj= new InputObject();

        Event e = Event.current;
        if(e.isKey){
            
        obj.key= "keyboard "  + e.KeyCode; 
        obj.mMinutes_ = mMinutes_;
        obj.mSeconds_ = mSeconds_;
        }
        return obj;
    }

   
    public InputObject getMouseInput() {
        InputObject obj= new InputObject();
        Event e= Event.current;
        if(e.isMouse){
       
        obj.key = "Mouse" + e.button +" position:"+ Input.mousePosition.x + " "+ Input.mousePosition.y;
        obj.mMinutes_ = mMinutes_;
        obj.mSeconds_ = mSeconds_;
        
        }
        return obj;
    }

    //REVISAR ESTO
    public InputObject getGamePadInput() {
        InputObject obj= new InputObject();

        obj.key = "Gamepad";
        obj.mMinutes_ = mMinutes_;
        obj.mSeconds_ = mSeconds_;

        return obj;
    }

    void compruebaInput() {
        Debug.Log("bla");       
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

        if(manager.gameMode_ == GM.READINGINPUT)
            compruebaInput();
        
    }


}
