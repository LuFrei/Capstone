using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryShooter : MonoBehaviour {



    public float waitTime = 3f;
    private float currentTime;
    private bool hasAttacked = false;
    private bool hasShot = false;

    public SimpleTrigger trigger;
    public GameObject bullet;
    public Transform bulletPoint;
    public Transform target;

    public Vector2 angleDiff;

    #region AnimParameters
    bool isIdle = true;
    bool isAlert = false;
    bool isShooting = false;
    bool isDead = false;
    #endregion

    void Start () {
        trigger = GetComponentInChildren<SimpleTrigger>();
        currentTime = waitTime;
	}

    private void Update() {

        if (trigger.triggered) {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0) {
                Shoot(DetectTargetAngle());
                currentTime = waitTime;
            }
        }

        Debug.Log("target angle: " + DetectTargetAngle());
    }

    float DetectTargetAngle() {
        angleDiff = transform.position - target.position;
        return Vector2.Angle(angleDiff, Vector2.right * -1);
    }

    void Shoot(float fireAngle) {


        Instantiate(bullet, bulletPoint.position, Quaternion.Euler(0, 0, fireAngle));
    }
}