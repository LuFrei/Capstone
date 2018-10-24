using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallSpawner : MonoBehaviour {

    public float spawnTimer;
    float currentTime;
    public GameObject cannonball;

	// Use this for initialization
	void Start () {
        currentTime = spawnTimer;
	}
	
	// Update is called once per frame
	void Update () {
        currentTime -= Time.deltaTime;

        if(currentTime <= 0) {
            Instantiate(cannonball, transform.position, Quaternion.identity);
            currentTime = spawnTimer;
        }
	}
}
