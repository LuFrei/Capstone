using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempLevel2End : MonoBehaviour
{
	PlayerController player;
	Rigidbody2D playerBody;

	private void Start() {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		playerBody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.CompareTag("Player")) {
			player.inDialogue = true;
			playerBody.gravityScale = 1;
			playerBody.drag = 1;
		}
	}
}
