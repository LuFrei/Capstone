using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneTimeTrigger : MonoBehaviour {

    public bool hasTriggered = false;
    public bool isActive = true;

    public CameraSystem cam;
    public Transform newTarget;

	// Use this for initialization
	void Start () {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if(hasTriggered && isActive) {
            cam.target = newTarget;        }
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!hasTriggered) {
            if (collision.gameObject.CompareTag("Player")) {
                hasTriggered = true;
            }
        }
    }
}
