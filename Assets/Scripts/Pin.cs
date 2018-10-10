using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public GameObject _target;

    float _xTarget;
    float _yTarget;
    float _zTarget;

    public float _xOffset;
    public float _yOffset;
    public float _zOffset;

    public bool _xConstrain;
    public bool _yConstrain;
    public bool _zConstrain;




    void Update () {
        _xTarget = _target.transform.position.x;
        _yTarget = _target.transform.position.y;
        _zTarget = _target.transform.position.z;

        if(_xConstrain) 
            _xTarget = 0;
        if (_yConstrain)
            _yTarget = 0;
        if (_zConstrain)
            _zTarget = 0;

        gameObject.transform.position = new Vector3(_xTarget + _xOffset, _yTarget + _yOffset, _zTarget + _zOffset);
	}
}
