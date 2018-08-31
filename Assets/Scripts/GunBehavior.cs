using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehavior : MonoBehaviour {

    public int gunType;     // 0: None, 1:Pistol 2:MachineGun
    GameObject bulletPoint;
    public GameObject bullet;
    float playerAngle;

    private void Start() {
        bulletPoint = gameObject.transform.Find("BulletSpawn").gameObject;

    }

    public void Shoot(float fireAngle) {
        switch (gunType) {
            case 0:
                //save this for melee
                break;
            case 1:
                Instantiate(bullet, bulletPoint.transform.position, Quaternion.AngleAxis(fireAngle, Vector3.forward));
                break;
            case 2:
                //save for machine gun
                break;
        }
    }
}
