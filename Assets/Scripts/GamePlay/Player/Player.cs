using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    //This script should keep track of the Status and statistics of the player.

    public Transform deathBox;
    public Transform currentSpawn;

    public int health;
    public float speed;
    public float jumpHeight;

    public bool playerDead = true;
    public bool invulnerable = false;
    float invulnerabilityTimer;

    public GameManager gameManager;

    #region Player States
    public bool facingLeft;
    public enum PlayerLookState { Forward, Up, Down };
    public PlayerLookState playerState;
    #endregion

    protected virtual void Update() {

        //if 0 or less health, die
        if (health <= 0) {
            Debug.Log("I have less than 0 health!!@$");
            Die();
        }

        //if invulnerable, countdown to vulnerable
        if (invulnerable) {
            StartCoroutine(Invulnerability());
        }
    }

    protected void Die() {
        Debug.Log("I am doing the Death loop now");
        playerDead = true;
        gameObject.transform.position = deathBox.position;
        health = 5;
    }
    
    /// <summary>
    /// Deals damage to the player
    /// </summary>
    /// <param name="damageValue">How much damage to deal</param>
    /// <param name="time">How long invulnerability should last</param>
    public void Damage(int damageValue, float time) {
        //Subtract damage from health if not invulnerable
        if (!invulnerable) {
            health -= damageValue;
            invulnerable = true;
            invulnerabilityTimer = time;
        }
    }

    IEnumerator Invulnerability() { 
        while(invulnerabilityTimer > 0) {
            invulnerabilityTimer -= Time.deltaTime;
            yield return null;
        }
        invulnerable = false;
    }
}
