using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour {

    public bool isGrounded;


    //public Vector2 originOffset;
    //Vector2 originPoint;
    //float rayLength = 0.1f;

    private void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = false;
        }
    }
    //Currently unused, but WIP RayCast Ground detector
    //void GroundCast() {
    //    originPoint = new Vector2(gameObject.transform.position.x + originOffset.x, gameObject.transform.position.y + originOffset.y);
    //    RaycastHit2D hit = Physics2D.Raycast(originPoint, Vector2.down, rayLength, LayerMask.NameToLayer("Ground"));
    //    Debug.Log(hit.collider.name);
    //    Debug.DrawRay(originPoint, Vector2.down * rayLength, Color.red);
    //}
}