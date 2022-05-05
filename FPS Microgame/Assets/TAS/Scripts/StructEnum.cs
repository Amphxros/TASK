using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct InstruccionMouse
{
    int type; // izq, rueda, dch
    Vector3 position; //posicion de clickeo

    public InstruccionMouse( string ty, string[] pos)
    {
        this.type = int.Parse(ty);
        this.position =new Vector3(int.Parse(pos[0]), int.Parse(pos[1]), int.Parse(pos[2]) );
    }

}
public struct InstruccionKeycode
{
    KeyCode key;
    float timeClicked;

    public InstruccionKeycode(string k, string t)
    {
        this.key =  (KeyCode) System.Enum.Parse(typeof(KeyCode),  k);
        this.timeClicked = float.Parse(t);
    }
}

public struct InstruccionWait
{
    float timeWait;

    public InstruccionWait(string t)
    {
        this.timeWait = float.Parse(t);
    }
}