using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TASManager : MonoBehaviour
{
    [Header("Reading input or replaying input")]
    public GM gameMode_;
    private static TASManager mInstance_=null;

    public static TASManager getInstance(){ return mInstance_;}
    bool amItheInstance=false;

    Queue<InputObject> inputRecorded;
    Serializer serializer;
    //InputData dataCollector;

    void Awake()
    {
        if(mInstance_==null && !amItheInstance){
            mInstance_=this;
            amItheInstance=true;
            DontDestroyOnLoad(this);
            inputRecorded = new Queue<InputObject>();
            serializer = new Serializer("partida");
        }
        else{
            Destroy(this.gameObject);
        }
    }

    public void Play(){
        Debug.Log("playing");

    }
    public void Pause(){
        Debug.Log("pause");

    }
    public void Stop(){
        Debug.Log("stop");

    }
    public void Rewind(){
        Debug.Log("rewind");

    }

    public void saveInput(InputObject obj_) {
        inputRecorded.Enqueue(obj_);
    }

    void Update()
    {
        if (inputRecorded.Count > 0) {
            serializer.serializa(inputRecorded);
            inputRecorded.Clear();
        }
    }
}
