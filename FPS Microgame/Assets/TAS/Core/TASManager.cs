using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TASManager : MonoBehaviour
{
    [Header("Reading ipnut or replaying input")]
    public GM gameMode_;
    private static TASManager mInstance_=null;

    public TASManager getInstance(){ return mInstance_;}
    bool amItheInstance=false;

    Queue<InputObject> inputRecorded;
    InputData dataCollector;

    void Awake()
    {
        if(mInstance_==null && !amItheInstance){
            mInstance_=this;
            amItheInstance=true;
            DontDestroyOnLoad(this);
            inputRecorded = new Queue<InputObject>();
            dataCollector = new InputData();
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

    private void saveInput() {
        InputObject[] newInputs = dataCollector.getInputs();

        for (int i = 0; i < newInputs.Length; i++) {
            inputRecorded.Enqueue(newInputs[i]);
        }
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            saveInput();
        }

    }
}
