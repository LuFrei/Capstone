using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float _speed;
    bool _facingLeft;

    #region input vars
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
	void Update () {
        _yAxis = Input.GetAxisRaw("Vertical");
        _xAxis = Input.GetAxisRaw("Horizontal");
        _fire = Input.GetKeyDown(KeyCode.J);
        _jump = Input.GetKey(KeyCode.Space);

        Debug.Log("Facing Left is now equal to: " + _facingLeft);

        Orientate();

        if(_yAxis > 0)
            AimUp();

        if (_yAxis < 0) {
            Debug.Log("'down' is pressed");
            Crouch();
        }
        Debug.Log("My speed should be: " + _speed);
        if (_xAxis != 0)
            Move(_speed, Crouch());

        if (_fire)
            Shoot();

        if (_jump)
            Jump();
	}

    void Jump() {

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
            gameObject.transform.Translate(Vector3.left * _xAxis * (speed * modifier) * Time.deltaTime);
    }

    void Orientate() {
        if (_facingLeft)
             gameObject.transform.localEulerAngles = new Vector3(0,180,0);
        if(!_facingLeft)
            gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
    }

    void Shoot() {
        if(!_facingLeft)
            Instantiate(_bullet, _bulletPoint.transform.position, Quaternion.AngleAxis(gameObject.transform.localRotation.y, Vector3.forward));
        else if(_facingLeft)
            Instantiate(_bullet, _bulletPoint.transform.position, Quaternion.AngleAxis(gameObject.transform.localRotation.y + 180, Vector3.forward));
    }
}
