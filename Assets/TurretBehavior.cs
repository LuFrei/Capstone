using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : MonoBehaviour {

    //For now, script jsut deals in activating and deactivating laser

    public bool active; //Switches laser on/off
    GameObject laser;

	// Use this for initialization
	void Start () {
        laser = transform.Find("LaserPoint").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}