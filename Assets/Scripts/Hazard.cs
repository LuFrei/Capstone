﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {

	//GameObjects with this property deal damage to the player

    public int damageValue;
	public int invulnaribilityTime;
    Player player;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Debug.Log("I should be doing damage to player");
            player.Damage(damageValue, invulnaribilityTime);
        }
    }
}
