using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    //This script should keep track of the Status and statistics of the player.
    public GameObject currentSpawn;

    public int health;
    public float speed;
    public float jumpHeight;

	private bool deathDoop; //makes "die" only play once

    public bool playerDead = true; //start player as dead
    public bool invulnerable = false;
    public float spawnTimer;
    private float invulnerabilityTimer;

    public GameManager gameManager;

    #region Player States
    public bool facingLeft;
    public enum PlayerLookState { Forward, Up, Down };
    public PlayerLookState playerState;
    #endregion

    protected virtual void Update() {

        //if 0 or less health, die
        if ((health <= 0 && !playerDead && !deathDoop)) {
            //Debug.Log("I have less than 0 health!!@$");
            Die();
        }

        //if invulnerable, countdown to vulnerable
        if (invulnerable) {
            StartCoroutine(Invulnerability());
        }
    }

    protected void Die() {
        //Debug.Log("I am doing the Death loop now");
        playerDead = true;
		deathDoop = true;
        gameObject.transform.position = currentSpawn.transform.position;
    }

    protected void Respawn() {
        //Debug.Log("Respawning/ Recovering health");
        playerDead = false;
        health = 5;
		deathDoop = false;
        currentSpawn.GetComponent<Spawner>().OpenDoor();
    }
    
    /// <summary>
    /// Deals damage to the player
    /// </summary>
    /// <param name="damageValue">How much damage to deal</param>
    /// <param name="time">How long invulnerability should last</param>
    public void Damage(int damageValue, float time) {
        //Subtract damage from health if not invulnerable
        Debug.Log("Player Damage registered");
        if (!invulnerable) {
            Debug.Log("is vulnerable, and player should have damage taken away");
            health -= damageValue;
            invulnerable = true;
            invulnerabilityTimer = time;
        }
    }

    private IEnumerator Invulnerability() { 
        while(invulnerabilityTimer > 0) {
            invulnerabilityTimer -= Time.deltaTime;
            yield return null;
        }
        invulnerable = false;
    }
}
