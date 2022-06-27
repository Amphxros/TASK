using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct TransformState{
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;

    public TransformState(Vector3 position, Quaternion rotation, Vector3 scale){
        this.position = position;
        this.rotation = rotation;
        this.scale = scale;
    }
}

public class TASKTransformSyncer : MonoBehaviour
{
     public TASKManager mngr;

     public string customTag;
     public string recordingTagPrefix=>(string.IsNullOrEmpty(customTag) ?name : customTag) + "_transform";

     public bool syncPosition;
     public bool syncRotation;
     public bool syncScale;

     /// <summary>
     /// Update is called every frame, if the MonoBehaviour is enabled.
     /// </summary>
    void Update()
    {
         if(mngr == null)
         {
             Debug.LogError("TASKTransformSyncer: recorderToSyncTo is null");
             return;
         }
         if(!syncPosition && !syncRotation && !syncScale)
         {
             Debug.LogError("TASKTransformSyncer: nothing to sync");
             return;
         }

         if(mngr.Mode == InputTASKMode.Record){

         }
         else if(mngr.Mode==InputTASKMode.Playback){
    
         }
    }
    
    void MatchTransform(){
        

        if(syncPosition){
        
        }
        if(syncRotation){
        
        }
        if(syncScale){
        
        }

    }

    void recordTransform(){
        TransformState t= new TransformState(transform.position, transform.rotation, transform.localScale);
        string state= JsonUtility.ToJson(t);

    }

}