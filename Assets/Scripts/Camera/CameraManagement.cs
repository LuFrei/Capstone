using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManagement : MonoBehaviour {

    public Transform[] camPositions;

    public int currentPos;

	// Use this for initialization
	void Start () {
        currentPos = 0;
	}

    private void Update() {
        transform.position = camPositions[currentPos].position;
    }
}
