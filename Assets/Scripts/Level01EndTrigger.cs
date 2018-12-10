using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level01EndTrigger : MonoBehaviour {

    bool isActive = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isActive) {
            //Activate gas effects

            //Damage player until dead
        }
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            isActive = true;
        }
    }
}
