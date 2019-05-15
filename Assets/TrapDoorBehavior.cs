using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoorBehavior : MonoBehaviour
{
	public bool isOpen;

    public float speed;
    public float maxDistance;
	public float distanceDelta;
	public Vector3 startPosition;
    private Vector3 currentPos;


    Vector3 openDir = Vector3.right;

	private void Start() {
		startPosition = transform.position;
	}

	void UpdateDeltaPos() {
		distanceDelta = transform.position.x - startPosition.x ;

	}

    public IEnumerator Open() {
        //If door meets open conditions, open
        //else, exit without doing anything
        if (distanceDelta < maxDistance) {
            //While door is not fully open, keep opening
            while (distanceDelta < maxDistance) {
                //Debug.Log("I'm opening!");
                transform.Translate(openDir * speed * Time.deltaTime);
				UpdateDeltaPos();
                yield return null;

				if(currentPos.x > 10 || currentPos.x > 10 || currentPos.z > 10) {
					Debug.Log("We had to eject from loop");
					Debug.Log("x: " + currentPos.x + ", y: " + currentPos.y + ", z: " + currentPos.z);
				}
            }
        }
		isOpen = true;
	}

    //Follows same rules as Open()
    public IEnumerator Close() {
        if (distanceDelta > 0) {
            while(currentPos.x > 0){
                //Debug.Log("I'm closing!");
                transform.Translate(openDir * -speed * Time.deltaTime);
				UpdateDeltaPos();
                if (currentPos.x < 0) {
                    currentPos.x = 0;
                }
                yield return null;
            }
        }
		isOpen = false;
	}
}
