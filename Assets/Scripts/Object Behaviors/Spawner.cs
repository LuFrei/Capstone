 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Player player;
    public static GameObject[] spawnPoints;
    public int id;

    public bool active;
    public DoorBehavior door;

    private void Start() {
        if(id == 0) {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            player.currentSpawn = transform;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            door.open = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            door.open = false;
        }
    }
}
