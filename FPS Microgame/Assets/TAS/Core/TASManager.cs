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
    List<InputObject> inputToReproduce;
    Serializer serializer;
    Deserializer deserializer;
    //InputData dataCollector;
    public string filename;
    void Awake()
    {
        if(mInstance_==null && !amItheInstance){
            mInstance_=this;
            amItheInstance=true;
            DontDestroyOnLoad(this);
            inputRecorded = new Queue<InputObject>();
            serializer = new Serializer(filename);
        }
        else{
            Destroy(this.gameObject);
        }
    }

    public void Play(){
        Debug.Log("playing");
        Time.timeScale=1;
        deserializer= new Deserializer(filename);
        inputToReproduce= deserializer.deserialize();
        



    }
    public void Pause(){
        Debug.Log("pause");

        Time.timeScale = 0;

    }
    public void Stop(){
        Debug.Log("stop");
        Application.Quit();

    }
    public void Rewind(){
          Time.timeScale = -1;
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
