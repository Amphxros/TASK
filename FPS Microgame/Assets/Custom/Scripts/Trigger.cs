using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class Trigger : MonoBehaviour
{
    #region properties
    public Action Activate;
    #endregion

    #region parameters
    #endregion

    #region references
    #endregion

    #region methods
    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<Unity.FPS.Gameplay.PlayerCharacterController>())
            Activate();
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion
}
