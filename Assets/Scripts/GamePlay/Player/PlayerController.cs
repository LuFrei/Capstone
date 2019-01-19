using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class PlayerController : Player {

    RayCastDetector groundDetector;

    #region Input Vars
    public bool left;
    public bool right;
    public bool up;
    public bool down;
    bool fire;
    bool jump;
    #endregion

    Rigidbody2D rgb2d;

    public GameObject bulletPoint;
    public GameObject bullet;


	// Use this for initialization
	void Start () {
        rgb2d = GetComponent<Rigidbody2D>();
        groundDetector = GetComponentInChildren<RayCastDetector>();
    } 

    // Update is called once per frame
    protected override void Update() {
        if (!playerDead) {
            GetInput();
        }  

        //Checking last direction player was facing.
        if (left)
            facingLeft = true;
        else if (right)
            facingLeft = false;

        base.Update();

        Move (speed);

        if (jump){
            if (groundDetector.isGrounded) {
                Jump();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && currentSpawn.GetComponent<Spawner>().ready == true) {
            Respawn();
        }
    }


    
    void GetInput() {
        //Reset values
        //We want to make sure player is still holding down button
        left = false;
        right = false;
        up = false;
        down = false;
        fire = false;
        jump = false;

        //Individually assigning directions to bools in order for wall collision to work
        if (Input.GetAxisRaw("Vertical") > 0) {
            up = true;
        } else if (Input.GetAxisRaw("Vertical") < 0) {
            down = true;
        }

        if (Input.GetAxisRaw("Horizontal") > 0) {
            right = true;
        } else if (Input.GetAxisRaw("Horizontal") < 0) {
            left = true;
        }

        fire = Input.GetKeyDown(KeyCode.J);
        jump = Input.GetKeyDown(KeyCode.Space);
    }

    void Jump() {
        rgb2d.AddForce(Vector2.up + new Vector2(0 ,jumpHeight), ForceMode2D.Impulse);
    } 

    void Move(float speed) {

        if (groundDetector.isGrounded) {
            if (playerState == PlayerLookState.Down) {
                speed *= 0.5f;
            }
        }

        if (left && !groundDetector.leftWall) {
            gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
        } else if (right && !groundDetector.rightWall) {
            gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    //Experimental: I want to see if i can get something interesting going on here
    //WIP: Back logged for now until more important things are done
    void WallSlide() {
        rgb2d.gravityScale = 3;

        if (left && groundDetector.leftWall) {
            rgb2d.gravityScale = 1.7f;
        } else if (right && groundDetector.rightWall) {
            rgb2d.gravityScale = 1.7f;
        }
    }


    //Currently unused aiming code.
    //Keeping incase we get to implement it later. Don't watn to rewrite everythig, if I do.
    #region unused aim
    //void GenerateFireAngle() {
    //    switch (playerState) {
    //        case PlayerLookState.Forward:
    //            if (!facingLeft)
    //                fireAngle = 0;
    //            else if (facingLeft)
    //                fireAngle = 180;
    //            break;
    //        case PlayerLookState.Down:
    //            if (!groundDetector.isGrounded) {
    //                fireAngle = 270;
    //            } else if (groundDetector.isGrounded) {
    //                fireAngle = 0;
    //            }
    //            break;
    //        case PlayerLookState.Up:
    //            fireAngle = 90;
    //            break;
    //    }
    //}
    //void Aim() {
    //    if (yAxis == 0) {
    //        playerState = Player.PlayerLookState.Forward;
    //    } else if (yAxis < 0) {
    //        playerState = Player.PlayerLookState.Down;
    //    } else if (yAxis > 0) {
    //        playerState = Player.PlayerLookState.Up;
    //    }
    //}
    #endregion

}
