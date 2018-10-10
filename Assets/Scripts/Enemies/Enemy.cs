using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health;
    public float speed;

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Player Bullet")){
            health --;
        }
    }

    private void Update() {
        if(health <= 0) {
            Destroy(gameObject);
        }
    }
}
