using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    //This script should keep track of the Status and statistics of the player.

    
    
    public float speed;
    public float jumpHeight;
    public byte lives;

    public bool outOfLives = false;

    public Transform respawnPoint;

    #region Player States
    public bool facingLeft;
    public enum PlayerLookState { Forward, Up, Down };
    public PlayerLookState playerState;
    #endregion

    public bool isGrounded;

	// Use this for initialization
	void Start () {
        lives = 3;
	}
	
	// Update is called once per frame
	void Update () {
		if(lives <= 0) {
            //Trigger GameOver
            outOfLives = true;
        }
	}

    void Die() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Hazard")) {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Hazard")) {
            Die();
        }

        //Checks to see if player is grounded
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
}
