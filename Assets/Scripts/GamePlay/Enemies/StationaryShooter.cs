using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryShooter : MonoBehaviour {

    public int health;
    public float speed;



    public float waitTime = 3f;
    private float currentTime;

    public SimpleTrigger trigger;
    public GameObject bullet;
    public Transform bulletPoint;
    public Transform target;

    public Vector2 angleDiff;


    public GameObject angleDebug;

    #region AnimParameters
    Animator anim;

    public bool isHit = false;
    #endregion

    void Start () {
        anim = GetComponentInChildren<Animator>();
        trigger = GetComponentInChildren<SimpleTrigger>();
        currentTime = waitTime;
        
	}

    private void Update() {

        anim.SetBool("isHit", isHit);
        isHit = false; //Resets anim after hit


        if (trigger.triggered) {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0) {
                Shoot(DetectTargetAngle());
                currentTime = waitTime;
            }
        }

        if(health <= 0) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player Bullet")) {
            health--;
            isHit = true;
        }
    }

    float DetectTargetAngle() {
        angleDiff = transform.position - target.position;

        if (target.position.y > transform.position.y) {
            return Vector2.Angle(angleDiff, Vector2.left);
        }

        return Vector2.Angle(angleDiff, Vector2.right * 1) + 180;

    }

    void Shoot(float fireAngle) {
        Instantiate(bullet, bulletPoint.position, Quaternion.Euler(0, 0, fireAngle));
    }
}