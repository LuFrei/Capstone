using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public GameObject _target;
    
    public float _xOffset;
    public float _yOffset;
    public float _zOffset;
	
	void Update () {
        gameObject.transform.position = new Vector3(_target.transform.position.x + _xOffset, _target.transform.position.y + _yOffset, _target.transform.position.z + _zOffset);
	}
}
