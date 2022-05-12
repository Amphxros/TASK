using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFloor : MonoBehaviour
{
    #region parameters
    private bool activated = false;
    private float _counter = 0;
    #endregion

    #region properties
    [SerializeField] [Tooltip("Time it takes for the platform to fall")]
    private float _maxTime = 0.01f;
    [SerializeField]
    private GameObject _activatorObject;
    #endregion

    #region references
    private Transform _myTransform;
    private Trigger _trigger;
    private Rigidbody _myRigidbody;
    #endregion

    #region methods
    private void ActivateFalling() {
        activated = true;
    }

    // Start is called before the first frame update
    void Start() {
        _myTransform = transform;
        _trigger = _activatorObject.GetComponent<Trigger>();
        _trigger.Activate += ActivateFalling;
        _myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        if(activated) _counter += Time.deltaTime;
        if(_counter > _maxTime) {
            activated = false;
            _myRigidbody.useGravity = true;
            _myRigidbody.isKinematic = false;
        }
    }
    #endregion
}
