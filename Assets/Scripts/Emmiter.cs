using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emmiter : MonoBehaviour {

    public GameObject asset;
    public float rateOfSpawn;
    float timer;

   
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if(timer <= 0) {
            Instantiate(asset);
            timer = rateOfSpawn;
        }
	}
}