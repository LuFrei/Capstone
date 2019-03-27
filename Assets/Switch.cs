using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

	public bool ready;
	public bool on;
	public SpriteRenderer light;

	void Update() {
		if (ready && Input.GetKeyDown(KeyCode.UpArrow)) {
			Use();
		}
	}

	//If player is within trigger, switch is ready to use
	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.CompareTag("Player")) {
			ready = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision) {
		if (collision.gameObject.CompareTag("Player")) {
			ready = false;
		}
	}

	//on use, check if it's ready, if so, turn on
	void Use() {
		if (ready) {
			on = true;
			light.color = Color.green;
		}
	}
}
