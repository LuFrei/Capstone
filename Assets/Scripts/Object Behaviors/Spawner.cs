using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Player player;
    public static GameObject[] spawnPoints;
    public int id;

    public bool active;

    public GameObject door;
    DoorBehavior doorBehavior;

    void Start() {
        if(door != null) doorBehavior = door.GetComponent<DoorBehavior>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player") && door != null) {
            doorBehavior.open = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player") && door != null) {
            doorBehavior.open = false;
        }
    }
}
