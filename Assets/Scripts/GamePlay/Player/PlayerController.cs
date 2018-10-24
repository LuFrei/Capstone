﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class PlayerController : MonoBehaviour {
    //this script should only handle inputs and distributing instructions based on such.

    float fireAngle;

    #region Input Vars
    float yAxis;
    float xAxis;
    bool fire;
    bool jump;
    #endregion

    public GameObject bulletPoint;
    public GameObject bullet;

    public Transform respawnPoint;

    public Player player;

	// Use this for initialization
	void Start () {
        player = GetComponent<Player>();
	}


    // Update is called once per frame
    void Update() {

        GetInput();
        Aim();

        //Checking last direction player was facing.
        if (xAxis < 0)
            player.facingLeft = true;
        else if (xAxis > 0)
            player.facingLeft = false;

        //Giving bullet direction based on aim.

        Aim();
        GenerateFireAngle();
        Move (player.speed);

        if (fire) {
            Instantiate(bullet, bulletPoint.transform.position, Quaternion.AngleAxis(fireAngle, Vector3.forward));
        }

        if (jump && player.isGrounded)
            Jump();
    }


    
    void GetInput() {
        yAxis = Input.GetAxisRaw("Vertical");
        xAxis = Input.GetAxisRaw("Horizontal");
        fire = Input.GetKeyDown(KeyCode.J);
        jump = Input.GetKeyDown(KeyCode.Space);
    }

    void GenerateFireAngle() {
        switch (player.playerState) {
            case Player.PlayerLookState.Forward:
                if (!player.facingLeft)
                    fireAngle = 0;
                else if (player.facingLeft)
                    fireAngle = 180;
                break;
            case Player.PlayerLookState.Down:
                if (!player.isGrounded) {
                    fireAngle = 270;
                } else if (player.isGrounded) {
                    fireAngle = 0; 
                }
                break;
            case Player.PlayerLookState.Up:
                fireAngle = 90;
                break;
        }
    }

    void Jump() {
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up *  player.jumpHeight, ForceMode2D.Impulse);
    }

    float Crouch() {
        Debug.Log("I should be crouching");
        return 0.5f;

    }

    //Simple movement code
    void Move(float spd) {
        if (player.isGrounded) {
            if (Input.GetKey(KeyCode.LeftShift)) {
                spd *= 2f;
            } else if (player.playerState == Player.PlayerLookState.Down) {
                spd *= 0.5f;
            } else {
            }
        }

        gameObject.transform.Translate(Vector3.right * xAxis * spd * Time.deltaTime);
    }

    void Aim() {
        if (yAxis == 0) {
            player.playerState = Player.PlayerLookState.Forward;
        } else if (yAxis < 0) {
            player.playerState = Player.PlayerLookState.Down;
        } else if (yAxis > 0) {
            player.playerState = Player.PlayerLookState.Up;
        }
    }

    void Die() {
        transform.position = respawnPoint.position;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Hazard")) {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Hazard")) {
            Die();
        }
    }
}