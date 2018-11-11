using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour {

    public bool open;
    public float speed;

    public float maxDistance;
    public float currentPos = 0;

    public enum Direction { Horizontal, Vertical};
    public Direction doorStyle;

    Vector3 openDir;

    void Start () {
        SetUp();
	}
	
	// Update is called once per frame
	void Update () {

        if(open == true && currentPos < maxDistance) {
            transform.Translate(openDir * speed * Time.deltaTime);
            currentPos += (speed * Time.deltaTime);
        }

        if (open == false && currentPos > 0) {
            transform.Translate(openDir * -speed * Time.deltaTime);
            currentPos -= (speed * Time.deltaTime);
        }

        if(currentPos > maxDistance) {
            currentPos = maxDistance;
        }
        if(currentPos < 0) {
            currentPos = 0;
        }
    }

    //This will take inspector values and set up variables accordingly
    void SetUp() {
        switch (doorStyle) {
            case Direction.Horizontal:
                openDir = Vector3.right;
                break;
            case Direction.Vertical:
                openDir = Vector3.up;
                break;
        }
    }
}
