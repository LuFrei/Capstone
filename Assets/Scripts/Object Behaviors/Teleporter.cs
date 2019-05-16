using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

    public Teleporter otherTeleporter;
    public GameObject player;

    bool readyToUse;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (readyToUse && Input.GetKeyDown(KeyCode.UpArrow)) {
            player.transform.position = otherTeleporter.gameObject.transform.position;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            readyToUse = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            readyToUse = false;
        }
    }
}
