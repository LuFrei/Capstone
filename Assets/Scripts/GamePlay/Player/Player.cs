using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    //This script should keep track of the Status and statistics of the player.

    public float speed;
    public float jumpHeight;
    public int maxHealth;
    public int health;

    #region Player States
    public bool facingLeft;
    public enum PlayerLookState { Forward, Up, Down };
    public PlayerLookState playerState;
    #endregion

    public bool isGrounded;

	// Use this for initialization
	void Start () {
        health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        //Checks to see if player is grounded
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
}
