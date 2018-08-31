using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTest : MonoBehaviour {


    public float playerSpeed;
    float _speed;
    public float _jumpHeight;
    float _fireAngle;

    #region Player States
    bool _facingLeft;
    bool _isGounded;
    enum PlayerLookState { Forward, Up, Down};
    PlayerLookState _playerState;
    #endregion

    #region Input Vars
    float _yAxis;
    float _xAxis;
    bool _fire;
    bool _jump;
    #endregion

    public Animator anim;

	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
	}


    // Update is called once per frame
    void Update() {
        //Get Input From Keyboard
        _yAxis = Input.GetAxisRaw("Vertical");
        _xAxis = Input.GetAxisRaw("Horizontal");
        _fire = Input.GetKeyDown(KeyCode.J);
        _jump = Input.GetKey(KeyCode.Space);

        // movement modifiers should go back to default every frame, before checking to see if it should be altered
        _fireAngle = gameObject.transform.localRotation.y;          //What  am i trying to do with this?
        Debug.Log("the first angle is now: " + _fireAngle);
        _speed = playerSpeed;

        
        if (_yAxis == 0) {                                          //Checking to see where player is looking
            _playerState = PlayerLookState.Forward;
        } else if (_yAxis < 0) {
            _playerState = PlayerLookState.Down;
        } else if (_yAxis > 0) {
            _playerState = PlayerLookState.Up;
        }

        if (_xAxis < 0)
            _facingLeft = true;
        else if (_xAxis > 0)
            _facingLeft = false;

        //Set animation, bullet, and speed modifier based on States

        switch (_playerState) {
            case PlayerLookState.Forward:
                break;
            case PlayerLookState.Down:
                if (_isGounded) {                   //crouching effect
                    _speed = playerSpeed / 2;
                }else if (!_isGounded) {
                    if (_facingLeft)
                        _fireAngle = 90;
                    else
                        _fireAngle = 270;
                }
                break;
            case PlayerLookState.Up:
                if (_facingLeft)
                    _fireAngle = 270;
                else
                    _fireAngle += 90;
                break;
        }
        

        Orientate();

        if (_xAxis != 0)
            Move();

        if (_fire)
            gameObject.GetComponentInChildren<GunBehavior>().Shoot(_fireAngle);

        if (_jump && _isGounded)
            Jump();
    }


    //
    //Funcitons start from here, down
    //

    void Jump() {
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * _jumpHeight, ForceMode2D.Impulse);
    }

    void AimUp() {
  
    }

    float Crouch() {
        Debug.Log("I should be crouching");
        return 0.5f;

    }

    //Simple movement code
    void Move() {

        if (_facingLeft)
            _speed = -_speed;
        else
            _speed = Mathf.Abs(_speed);

            gameObject.transform.Translate(Vector3.right * _xAxis * _speed * Time.deltaTime);

    }

    void Orientate() {
        if (_facingLeft)
             gameObject.transform.localEulerAngles = new Vector3(0,180,0);
        if(!_facingLeft)
            gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
    }

    void Attack() {
        /*if(!_facingLeft)
            Instantiate(_bullet, _bulletPoint.transform.position, Quaternion.AngleAxis(_fireAngle, Vector3.forward));
        else if(_facingLeft)
            Instantiate(_bullet, _bulletPoint.transform.position, Quaternion.AngleAxis(_fireAngle + 180, Vector3.forward));*/
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        //Checks to see if player is grounded
        if (collision.gameObject.CompareTag("Ground"))
            _isGounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground"))
            _isGounded = false;
    }
}
