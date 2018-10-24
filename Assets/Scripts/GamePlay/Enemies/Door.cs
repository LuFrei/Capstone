using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public int health;

    Animator anim;
    bool isHit;


	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("isHit", isHit);
        isHit = false;

        if(health <= 0) {
            //Later I will replace this with an alternate frame for a destoryed door, and desactivate collider
            Destroy(gameObject);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Player Bullet")) {
            health--;
            isHit = true;
            anim.SetInteger("Health", health);
        }
    }
}
