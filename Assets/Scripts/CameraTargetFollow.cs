using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetFollow : MonoBehaviour {

    public Transform target;
    private Transform currentTrans;

    public enum TrackModes { XLock, YLock, Pin};
    public TrackModes trackMode;

	// Use this for initialization
	void Start () {
        currentTrans = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
        switch (trackMode) {
            case TrackModes.XLock:
                TrackX();
                break;
            case TrackModes.YLock:
                TrackY();
                break;
            case TrackModes.Pin:
                TrackAll();
                break;
        }       
    }

    void TrackX() {
        if(target.position.x > transform.position.x) {
            transform.position = new Vector3(target.position.x, currentTrans.position.y, currentTrans.position.z);
        }
    }

    void TrackY() {
        if (target.position.y > transform.position.y) {
            transform.position = new Vector3(currentTrans.position.x, target.position.y, currentTrans.position.z);
        }
    }

    void TrackAll() {
        transform.position = new Vector3(target.position.x, target.position.y, currentTrans.position.z);
    }
}
