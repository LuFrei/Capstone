using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehavior : MonoBehaviour {

    GameObject bulletPoint;
    GameObject bullet;

    private void Start() {
        bulletPoint = gameObject.transform.Find("BulletSpawn").gameObject;
    }

    public void Shoot() {
        Instantiate(bullet, bulletPoint.transform);
    }
}
