using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class PlayerController : Player {
    //this script should only handle inputs and distributing instructions based on such.

    float fireAngle;
    //GroundDetector groundDetector;
    RayCastDetector groundDetector;

    #region Input Vars
    float yAxis;
    float xAxis;
    bool fire;
    bool jump;
    #endregion

    public GameObject bulletPoint;
    public GameObject bullet;

    public Player player;

	// Use this for initialization
	void Start () {
        player = GetComponent<Player>();
        //groundDetector = GetComponentInChildren<GroundDetector>();
        groundDetector = GetComponentInChildren<RayCastDetector>();
    }


    // Update is called once per frame
    protected override void Update() {

        GetInput();
        Aim();

        //Checking last direction player was facing.
        if (xAxis < 0)
            facingLeft = true;
        else if (xAxis > 0)
            facingLeft = false;

        base.Update();

        //Giving bullet direction based on aim.
        Aim();
        GenerateFireAngle();
        Move (speed);

        if (fire) {
            Instantiate(bullet, bulletPoint.transform.position, Quaternion.AngleAxis(fireAngle, Vector3.forward));
        }

        if (jump && groundDetector.isGrounded)
            Jump();
    }


    
    void GetInput() {
        yAxis = Input.GetAxisRaw("Vertical");
        xAxis = Input.GetAxisRaw("Horizontal");
        fire = Input.GetKeyDown(KeyCode.J);
        jump = Input.GetKeyDown(KeyCode.Space);
    }

    void GenerateFireAngle() {
        switch (playerState) {
            case Player.PlayerLookState.Forward:
                if (!facingLeft)
                    fireAngle = 0;
                else if (facingLeft)
                    fireAngle = 180;
                break;
            case Player.PlayerLookState.Down:
                if (!groundDetector.isGrounded) {
                    fireAngle = 270;
                } else if (groundDetector.isGrounded) {
                    fireAngle = 0; 
                }
                break;
            case Player.PlayerLookState.Up:
                fireAngle = 90;
                break;
        }
    }

    void Jump() {
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpHeight, ForceMode2D.Impulse);
    }

    float Crouch() {
        Debug.Log("I should be crouching");
        return 0.5f;

    }

    //Simple movement code
    void Move(float spd) {
        if (groundDetector.isGrounded) {
            if (playerState == Player.PlayerLookState.Down) {
                spd *= 0.5f;
            }
        }
            gameObject.transform.Translate(Vector3.right * xAxis * spd * Time.deltaTime);
    }

    void Aim() {
        if (yAxis == 0) {
            playerState = Player.PlayerLookState.Forward;
        } else if (yAxis < 0) {
            playerState = Player.PlayerLookState.Down;
        } else if (yAxis > 0) {
            playerState = Player.PlayerLookState.Up;
        }
    }


}
