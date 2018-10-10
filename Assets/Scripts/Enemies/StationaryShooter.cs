using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryShooter : MonoBehaviour {

    private float waitTime = 0.5f;
    private bool hasAttacked = false;
    private bool hasShot = false;

    public SimpleTrigger trigger;
    public GameObject bullet;
    public GameObject bulletPoint;
    public Transform target;

    public float angle;
    public Vector2 angleDiff;

    #region AnimParameters
    bool isIdle = true;
    bool isAlert = false;
    bool isShooting = false;
    bool isDead = false;
    #endregion

    void Start () {
        trigger = GetComponentInChildren<SimpleTrigger>();
	}

    private void Update() {

        if (trigger.triggered) {
            Shoot(DetectTargetAngle());
        }

        Debug.Log("target angle: " + angle);
    }

    float DetectTargetAngle() {
        angleDiff = transform.position - target.position;
        return Vector2.Angle(Vector2.right, angleDiff);
    }

    void Shoot(float fireAngle) {
        
    }
}