using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour, ILockable {

    public bool isLocked { get; set; }

    public float speed;
    public float maxDistance;
    float currentPos = 0;

    public enum Direction { Horizontal, Vertical};
    public Direction doorStyle;

    public bool startOpen;

    Vector3 openDir;

    void Start () {
        SetUp();
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

        if (startOpen) {
            StartCoroutine(Open());
        }
    }

    public IEnumerator Open() {
        //If door meets open conditions, open
        //else, exit without doing anything
        if (!isLocked && currentPos < maxDistance) {
            //While door is not fully open, keep opening
            while (currentPos < maxDistance) {
                Debug.Log("I'm opening!");
                transform.Translate(openDir * speed * Time.deltaTime);
                currentPos += (speed * Time.deltaTime);
                //Check if door didn't exceed maximum open position
                if (currentPos > maxDistance) {
                    currentPos = maxDistance;
                }
                yield return null;
            }
        }
    }

    //Follows same rules as Open()
    public IEnumerator Close() {
        if (!isLocked && currentPos > 0) {
            while(currentPos > 0){
                Debug.Log("I'm closing!");
                transform.Translate(openDir * -speed * Time.deltaTime);
                currentPos -= (speed * Time.deltaTime);
                if (currentPos < 0) {
                    currentPos = 0;
                }
                yield return null;
            }
        }
    }
}
