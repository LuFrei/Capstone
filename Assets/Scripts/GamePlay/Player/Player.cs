using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    //This script should keep track of the Status and statistics of the player.

    public Transform deathBox;

    public int health;
    public float speed;
    public float jumpHeight;

    public bool playerDead = true;

    public GameManager gameManager;

    #region Player States
    public bool facingLeft;
    public enum PlayerLookState { Forward, Up, Down };
    public PlayerLookState playerState;
    #endregion

	// Use this for initialization
	void Start () {
        deathBox = GameObject.FindGameObjectWithTag("Death Point").transform;
	}

    protected virtual void Update() {
        if (health <= 0) {
            Debug.Log("I have less than 0 health!!@$");
            Die();
        }
    }

    protected void Die() {
        Debug.Log("I am doing the Death loop now");
        playerDead = true;
        gameObject.transform.position = deathBox.position;
        health = 5;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Hazard")) {
            health -= collision.gameObject.GetComponent<Hazard>().value;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Hazard")) {
            health -= collision.gameObject.GetComponent<Hazard>().value;
        }
    }
}
