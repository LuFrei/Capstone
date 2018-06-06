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

    public GameObject _bullet;
    public GameObject _bulletPoint;

	// Use this for initialization
	void Start () {

	}

    // Update is called once per frame
    void Update() {
        //Get Input From Keyboard
        _yAxis = Input.GetAxisRaw("Vertical");
        _xAxis = Input.GetAxisRaw("Horizontal");
        _fire = Input.GetKeyDown(KeyCode.J);
        _jump = Input.GetKey(KeyCode.Space);

        // if Fire Angle should fall back to default every frame, before checking to see if it should be turned
        _fireAngle = gameObject.transform.localRotation.y;

        // First I want to get the input and know where the player is looking
        if (_yAxis == 0) {
            _playerState = PlayerLookState.Forward;
        } else if (_yAxis < 0) {
            _playerState = PlayerLookState.Down;
        } else if (_yAxis > 0) {
            _playerState = PlayerLookState.Up;
        }



            if (_yAxis < 0) {
                Debug.Log("'down' is pressed");
                Crouch();
            }
        Debug.Log("My speed should be: " + _speed);

        Orientate();

        if (_xAxis != 0)
            Move();

        if (_fire)
            Shoot();

        if (_jump && _isGounded)
            Jump();
	}

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
    void Move(float speed, float modifier) {
        if(modifier == 0) {
            modifier = 1;
        }
        else if(modifier != 0) {
            modifier = modifier;    
        }

        if (_xAxis < 0)
            _facingLeft = true;
        if (_xAxis > 0)
            _facingLeft = false;

        if(!_facingLeft)
            gameObject.transform.Translate(Vector3.right * _xAxis * (speed * modifier) * Time.deltaTime);
        if(_facingLeft)
            gameObject.transform.Translate(Vector3.right * _xAxis * (-speed * modifier) * Time.deltaTime);
    }

    void Orientate() {
        if (_facingLeft)
             gameObject.transform.localEulerAngles = new Vector3(0,180,0);
        if(!_facingLeft)
            gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
    }

    void Shoot() {
        if(!_facingLeft)
            Instantiate(_bullet, _bulletPoint.transform.position, Quaternion.AngleAxis(_fireAngle, Vector3.forward));
        else if(_facingLeft)
            Instantiate(_bullet, _bulletPoint.transform.position, Quaternion.AngleAxis(_fireAngle + 180, Vector3.forward));
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")){
            _isGounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
                _isGounded = false;
            }
    }


}
