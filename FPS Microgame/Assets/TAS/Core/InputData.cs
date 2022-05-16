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


    void compruebaInput() {
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            InputObject obj;

            obj.key = "q";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            InputObject obj;

            obj.key = "w";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            InputObject obj;

            obj.key = "e";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            InputObject obj;

            obj.key = "r";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            InputObject obj;

            obj.key = "t";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            InputObject obj;

            obj.key = "y";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            InputObject obj;

            obj.key = "u";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            InputObject obj;

            obj.key = "i";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            InputObject obj;

            obj.key = "o";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            InputObject obj;

            obj.key = "p";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            InputObject obj;

            obj.key = "a";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            InputObject obj;

            obj.key = "s";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            InputObject obj;

            obj.key = "d";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            InputObject obj;

            obj.key = "f";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            InputObject obj;

            obj.key = "g";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            InputObject obj;

            obj.key = "h";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            InputObject obj;

            obj.key = "j";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            InputObject obj;

            obj.key = "k";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            InputObject obj;

            obj.key = "l";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            InputObject obj;

            obj.key = "z";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            InputObject obj;

            obj.key = "x";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            InputObject obj;

            obj.key = "c";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            InputObject obj;

            obj.key = "v";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            InputObject obj;

            obj.key = "b";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            InputObject obj;

            obj.key = "n";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            InputObject obj;

            obj.key = "m";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            InputObject obj;

            obj.key = "esc";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            InputObject obj;

            obj.key = "enter";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            InputObject obj;

            obj.key = "del";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            InputObject obj;

            obj.key = "space";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            InputObject obj;

            obj.key = "leftArrow";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            InputObject obj;

            obj.key = "rightArrow";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            InputObject obj;

            obj.key = "upArrow";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            InputObject obj;

            obj.key = "downArrow";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            InputObject obj;

            obj.key = "0";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            InputObject obj;

            obj.key = "1";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            InputObject obj;

            obj.key = "2";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            InputObject obj;

            obj.key = "3";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            InputObject obj;

            obj.key = "4";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            InputObject obj;

            obj.key = "5";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            InputObject obj;

            obj.key = "6";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            InputObject obj;

            obj.key = "7";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            InputObject obj;

            obj.key = "8";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            InputObject obj;

            obj.key = "9";
            obj.mMinutes_ = mMinutes_;
            obj.mSeconds_ = mSeconds_;

            manager.saveInput(obj);
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

        if(manager.gameMode_ == GM.READINGINPUT)
            compruebaInput();
        
    }


}
