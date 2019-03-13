using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour {

    public GameObject newSpawn;
    SpawnManager spawnManager; 

    private void Start() {
        spawnManager = GameObject.FindGameObjectWithTag("LevelController").GetComponent<SpawnManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
			spawnManager.SetNewSpawn(newSpawn);
        }
    }
}
