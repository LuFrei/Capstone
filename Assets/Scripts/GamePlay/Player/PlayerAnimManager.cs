using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimManager : MonoBehaviour {

    //public Transform playerRender;
    public Player player;
    public GroundDetector groundDetector;
  
    public bool isSprinting;
    public bool isCrouched;
    public bool isSliding;

    public bool isJumping;
    public bool isShooting;

    public bool isLookingUp;
    public bool isLookingStraight;
    public bool isLookingDown;

    public bool isFacingLeft;

    public bool isMoving;

    // Use this for initialization
    void Start () {
        player = GetComponentInParent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        

        //Link Input to parameters
		if(Input.GetAxis("Horizontal") != 0) {
            isMoving = true;
        } else {
            isMoving = false;
        }

        if(Input.GetAxis("Horizontal") < 0) {
            isFacingLeft = true;
        } else if (Input.GetAxis("Horizontal") > 0) {
            isFacingLeft = false;
        }

        if(isMoving && Input.GetKey(KeyCode.LeftShift)) {
            isSprinting = true;
        } else {
            isSprinting = false;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            isLookingUp = true;
        } else if (Input.GetKeyUp(KeyCode.UpArrow)) {
            isLookingUp = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && !groundDetector.isGrounded) {
            isLookingDown = true;
        } else if (Input.GetKeyUp(KeyCode.DownArrow) || groundDetector.isGrounded) {
            isLookingDown = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && groundDetector.isGrounded) {
            isCrouched = true;
        } else if (Input.GetKeyUp(KeyCode.DownArrow) || !groundDetector.isGrounded){
            isCrouched = false;
        }

        if (!isLookingDown && !isLookingUp) {
            isLookingStraight = true;
        } else {
            isLookingStraight = false;
        }


        if (isFacingLeft) {
            transform.localScale = new Vector2(-1, 1);
        } else if (!isFacingLeft){
            transform.localScale = new Vector2(1, 1);
        }

    }
}
