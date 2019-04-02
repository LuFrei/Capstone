﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
	private GameManager gm;
	public int levelIndex;

	private void Start() {
		gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.CompareTag("Player")) {
			gm.GoToLevel(levelIndex);
		}
	}
}
