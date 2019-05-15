using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Player player;
    //public static GameObject[] spawnPoints;
    public bool firstSpawn;

    private GameObject door;

    public bool active = false;
    public bool ready = false;
    private bool doop = true; //doop is used solely so "Countdown" isn't called indefinitely

    private Animator anim;

    private void Start() { 
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        anim = GetComponentInChildren<Animator>();

        door = transform.Find("Door").gameObject;
        if (firstSpawn) {
            active = true;
            player.currentSpawn = this.gameObject;
			player.transform.position = gameObject.transform.position; //we need this so player is in correct spawner when in new scene
        }
    }

    private void Update() {
        anim.SetBool("active", active);
        anim.SetBool("ready", ready);

		//if active, check when player can spawn
        if (active) {
			//Debug.Log(gameObject.name + " is active.");
            if (player.playerDead && !ready && doop) {
				//Debug.Log("Starting countdown");
                StartCoroutine(Countdown(2));
                doop = false;
            } else if (!player.playerDead) {
                ready = false;	//make sure if player alive, spawner can't be ready
                doop = true;
            }
        }
    }

    IEnumerator Countdown(float time) {
        while(time > 0) {
            time -= Time.deltaTime;
            yield return null;
        }
		//Debug.Log("I'm ready to respawn!");
        ready = true;
    }

    public void OpenDoor() {
        door.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == ("Player")) {
            //door reactivates wonce player leaves box
            door.SetActive(true);
        }
    }
}
