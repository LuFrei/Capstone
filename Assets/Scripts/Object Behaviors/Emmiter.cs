using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emmiter : MonoBehaviour {

    public GameObject asset;
    public float rateOfSpawn;

	private float timer;

	public bool moveObject;
	public float speed;
	public enum Direction { Up, Down, Left, Right};
	public Direction direction;

	private void Start() {
		SetTransform();
		if (moveObject) {
			SetMovement();
		}
	}


	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if(timer <= 0) {
            Instantiate(asset);
            timer = rateOfSpawn;
        }
	}



	//This method sets asset to be spawned's transform that to the transform of the emmiter object
	void SetTransform() {
		//Set asset Transform
		asset.transform.position = this.transform.position;		//position
		asset.transform.rotation = this.transform.rotation;		//rotation
		asset.transform.localScale = this.transform.localScale; //scale
	}

	void SetMovement() {
		asset.GetComponent<Move>().speed = speed;
		asset.GetComponent<Move>().direction = (Move.Direction)direction;
	}
} 