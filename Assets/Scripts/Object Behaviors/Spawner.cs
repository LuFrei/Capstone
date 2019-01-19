using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Player player;
    //public static GameObject[] spawnPoints;
    public bool firstSpawn;

    GameObject door;

    public bool active;
    public bool ready;
    bool doop;

    Animator anim;

    void Start() {
        anim = GetComponentInChildren<Animator>();

        door = transform.Find("Door").gameObject;
        if (firstSpawn) {
            active = true;
            player.currentSpawn = this.gameObject;
        }
    }

    private void Update() {
        anim.SetBool("active", active);
        anim.SetBool("ready", ready);

        if (active) {
            if (player.playerDead && !ready && doop) {
                StartCoroutine(Countdown(2));
                doop = false;
            } else if(!player.playerDead){
                ready = false;
                doop = true;
            }
        }
    }

    IEnumerator Countdown(float time) {
        while(time > 0) {
            time -= Time.deltaTime;
            yield return null;
        }
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
