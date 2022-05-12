using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSourceMusic;
    [SerializeField]
    private GameObject _activatorObject;
    private Trigger trigger;
    [SerializeField]
    private AudioSource _audioSourceAmbient;

    private void PlayMusic() {
        _audioSourceMusic.enabled = true;
        _audioSourceAmbient.enabled = false;
    }

    void Start() { //MUY IMPORTANTE PARA QUE EL TRIGGER FUNCIONE!!!
        trigger = _activatorObject.GetComponent<Trigger>();
        trigger.Activate += PlayMusic; //En vez de PlayMusic, el nombre del método que quieres que se active
    }
}
