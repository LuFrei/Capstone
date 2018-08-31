using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour {



    public enum Weapons { fists, pistol, machineGun };
    public Weapons equippedWeapon;
    PlayerControllerTest player;

    GameObject pistol;
    GameObject machineGun;
    bool showPistol;
    bool showMachineGun;
     

	// Use this for initialization
	void Start () {
        showPistol = false;
        showMachineGun = false; 
	}
	
	// Update is called once per frame
	void Update () {
        //ShowWeapon();
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Weapon")){
            GunBehavior weapon = collision.gameObject.GetComponent<GunBehavior>();
            WeaponEquip(weapon);
                
        }
    }

    void WeaponEquip (GunBehavior weapon) {
        switch (weapon.gunType) {
            case 0:
                equippedWeapon = Weapons.fists;
                break;
            case 1:
                equippedWeapon = Weapons.pistol;
                break;
            case 2:
                equippedWeapon = Weapons.machineGun;
                break;
        }
            Destroy(weapon.gameObject);
    }

    /*void ShowWeapon() {
        switch (equippedWeapon) {
            case Weapons.fists:
                showPistol = false;
                showMachineGun = false;
                break;
            case Weapons.pistol:
                showPistol = true;
                showMachineGun = false;
                break;
            case Weapons.machineGun:
                showPistol = false;
                showMachineGun = true;
                break;
        } 
    }*/

}
