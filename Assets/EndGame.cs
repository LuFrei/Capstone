using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
	public bool ready = false;

	private void Update() {
		if (ready) {
			if (Input.GetKey(KeyCode.Escape)) {
				Application.Quit();
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.CompareTag("Player")){
			ready = true;
		}
	}
}
