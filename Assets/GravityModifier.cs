using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityModifier : MonoBehaviour
{
	public float modifier;

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag("Player")) {
			other.GetComponent<Rigidbody2D>().gravityScale = modifier;
		}
	}

	private void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.CompareTag("Player")) {
			other.GetComponent<Rigidbody2D>().gravityScale = 3;
		}
	}
}
