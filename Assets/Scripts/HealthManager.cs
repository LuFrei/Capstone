using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {

    public int maxHealth;
    public int health;

    public bool isDead;
    public bool knockBack;

    public bool isInvulnerable;
    public float invulnerabilityDuration;

    public string target;
    public GameObject lifeUp;

	void Start () {
        isInvulnerable = false;
        health = maxHealth;
        Physics2D.IgnoreLayerCollision(9, 8);
    }

    void Update() {
        if(health <= 0) {
            isDead = true;
        } else {
            isDead = false;
        }

        if(health > maxHealth) {
            health = maxHealth;
        }

        if (isInvulnerable) {
            StartCoroutine(InvulnerabilityCountdown(invulnerabilityDuration));
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag(target)) {
            Debug.Log("Registered as target");
            if (!isInvulnerable) {
                Hit();
            }
        }

        if (collision.gameObject == lifeUp) {
            health += 1;
        }
    }

    void Hit() {
        Debug.Log("Hit initiated");
        health -= 1;
        isInvulnerable = true;
        if (knockBack) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2, 1) );
            
        }
    }

    IEnumerator InvulnerabilityCountdown(float invDur) {
        if(invDur > 0) {
            invDur -= Time.deltaTime;
        } else if(invDur <= 0) {
            isInvulnerable = false;
        }
        Debug.Log("invDur is now at: " + invDur);
        yield return null;
    }
}
