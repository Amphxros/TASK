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

    void Awake()
    {
        if(mInstance_==null && !amItheInstance){
            mInstance_=this;
            amItheInstance=true;
            DontDestroyOnLoad(this);
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

}
