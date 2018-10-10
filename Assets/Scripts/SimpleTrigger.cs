using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTrigger : MonoBehaviour {

    public bool triggered;
    public string target;
    


    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag(target))
            triggered = true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag(target))
            triggered  = false;
    }

}
