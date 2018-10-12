using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHealth : MonoBehaviour {

    public int health = 10;
    public Animator anim;
    public bool hit;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        anim.SetBool("Hit", hit);
	}
	
	// Update is called once per frame
	void Update () {
        hit = false;

        if(health <= 0) {
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Player Bullet")) {
            health -= 1;
            hit = true;
        }
    }
}
