using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour, ILockable {

	public bool isOpen;

    public bool isLocked { get; set; }

    public float speed;
    float maxDistance = 3;
	float lastPosition = 0;
    Vector3 currentPos;

    public bool startOpen;

    Vector3 openDir = Vector3.up;

    void Start () {
        SetUp();
	}

    //This will take inspector values and set up variables accordingly
    void SetUp() {
        if (startOpen) {
            StartCoroutine(Open());
        }
    }

	void UpdateCurrentPos() {
		currentPos = transform.localPosition;
	}

    public IEnumerator Open() {
        //If door meets open conditions, open
        //else, exit without doing anything
        if (!isLocked && currentPos.y < maxDistance) {
            //While door is not fully open, keep opening
            while (currentPos.y < maxDistance) {
                //Debug.Log("I'm opening!");
                transform.Translate(openDir * speed * Time.deltaTime);
				UpdateCurrentPos();
                //Check if door didn't exceed maximum open position
                if (currentPos.y > maxDistance) {
                    currentPos.y = maxDistance;
                }
                yield return null;

				if(currentPos.x > 10 || currentPos.y > 10 || currentPos.z > 10) {
					Debug.Log("We had to eject from loop");
					Debug.Log("x: " + currentPos.x + ", y: " + currentPos.y + ", z: " + currentPos.z);
				}
            }
        }
		isOpen = true;
	}

    //Follows same rules as Open()
    public IEnumerator Close() {
        if (!isLocked && currentPos.y > 0) {
            while(currentPos.y > 0){
                //Debug.Log("I'm closing!");
                transform.Translate(openDir * -speed * Time.deltaTime);
				UpdateCurrentPos();
                if (currentPos.y < 0) {
                    currentPos.y = 0;
                }
                yield return null;
            }
        }
		isOpen = false;
	}
}
