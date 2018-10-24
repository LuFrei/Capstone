using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour {

    public Animator anim;
    public bool hitGround;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        hitGround = true;
        anim.SetBool("hitGround", hitGround);
    }

    

}
