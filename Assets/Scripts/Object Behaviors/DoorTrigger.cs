using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour {

    public DoorBehavior door;

    //The Open and the Close types are "One Shot": Opens/Clsoes all the way on triggerEnter
    //Open and Close are continuous: Opens when enter trigger, closes when you leave.
    public enum TriggerType { Open, Close, OpenAndClose};
    public TriggerType function;

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.CompareTag("Player")) {
            switch(function){
                case TriggerType.Open:
                    StartCoroutine(door.Open());
                    break;
                case TriggerType.Close:
                    StartCoroutine(door.Close());
                    break;
                case TriggerType.OpenAndClose:
                    Stop();
                    StartCoroutine(door.Open());
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player") && function == TriggerType.OpenAndClose) {
            Stop();
            StartCoroutine(door.Close());
        }
    }

    void Stop() {
        //Today I learned that coroutines exist where they are being called
        //and a "new one" is created everytime you call it. 
        //Also that "StopCoroutine" needs to be in the same script that
        //the coroutines I want stopped is being called from.
        //... Further research is required to find out more about these
        //... "Coroutines."
        StopAllCoroutines();
    }
}
