using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimManager : MonoBehaviour {

    //public Transform playerRender;
    private PlayerController player;
    private RayCastDetector raycastDetector;
    private Animator anim;
  
	public float yDelta;
	private float lastYPos = 0;

    public bool isCrouched;

    public bool isJumping;
    public bool isShooting;

    public bool isLookingUp;
    public bool isLookingStraight;
    public bool isLookingDown;

    public bool isFacingLeft;

    public bool isMoving;

    // Use this for initialization
    void Start () {
        player = GetComponentInParent<PlayerController>();
        raycastDetector = GetComponentInParent<RayCastDetector>();
        anim = GetComponent<Animator>(); 
	}
	
	// Update is called once per frame
	void Update () {
		GetValues();
		SetParameters();
		lastYPos = transform.position.y;

    }

	void GetValues() {
        //Link Input to vars
		if(player.right || player.left) {
            isMoving = true;
        } else {
            isMoving = false;
        }

		yDelta = transform.position.y - lastYPos;

        if(Input.GetAxis("Horizontal") < 0) {
            isFacingLeft = true;
        } else if (Input.GetAxis("Horizontal") > 0) {
            isFacingLeft = false;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            isLookingUp = true;
        } else if (Input.GetKeyUp(KeyCode.UpArrow)) {
            isLookingUp = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && !raycastDetector.isGrounded) {
            isLookingDown = true;
        } else if (Input.GetKeyUp(KeyCode.DownArrow) || raycastDetector.isGrounded) {
            isLookingDown = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && raycastDetector.isGrounded) {
            isCrouched = true;
        } else if (Input.GetKeyUp(KeyCode.DownArrow) || !raycastDetector.isGrounded){
            isCrouched = false;
        }

        if (!isLookingDown && !isLookingUp) {
            isLookingStraight = true;
        } else {
            isLookingStraight = false;
        }

        //mirror
        if (isFacingLeft) {
            transform.localScale = new Vector2(-1, 1);
        } else if (!isFacingLeft){
            transform.localScale = new Vector2(1, 1);
        }
	}

	void SetParameters() {
		anim.SetBool("isMoving", isMoving);
		anim.SetBool("isGrounded", raycastDetector.isGrounded);
		anim.SetFloat("yDelta", yDelta);
	}
}
