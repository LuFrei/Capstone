using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideTurret : MonoBehaviour {

    public float speed;
    public float rateOfFire;

    float timer;

    public GameObject bullet;
    public Transform bulletPoint;
    Vector3 direction = Vector3.right;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Move
        transform.Translate(direction * speed * Time.deltaTime);

        //Shoot
        timer--;
        if (timer <= 0) {
            Instantiate(bullet, bulletPoint.position, Quaternion.Euler(0, 0, 0));
            timer = rateOfFire;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("I collided");
        if(collision.gameObject.CompareTag("Turret Limit")) {
            Debug.Log("I collided with a turret limit");
            if (direction == Vector3.right) {
                direction = Vector3.left;
            } else {
                direction = Vector3.right;
            }
        }
    }
}
