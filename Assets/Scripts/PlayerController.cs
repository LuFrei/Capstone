using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InputManager;

public class PlayerController : MonoBehaviour {

    public float _speed;

    public GameObject _bullet;
    public GameObject _bulletPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        if(_yAxis > 0)
            AimUp();

        if (_xAxis != 0) 
            Move();

        if (_fire)
            Shoot();
	}

    void AimUp() {

    }

    //Simple movement code
    void Move() {


        gameObject.transform.Translate(Vector3.right * _xAxis * _speed * Time.deltaTime);
    }

    void Shoot() {
        Instantiate(_bullet, _bulletPoint.transform.position, Quaternion.AngleAxis(gameObject.transform.localRotation.y, Vector3.forward));
    }
}
