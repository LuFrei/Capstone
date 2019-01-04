using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastDetector : MonoBehaviour {

    public bool isGrounded;

    Vector2 baseCoord;

    RaycastHit2D[] groundHit = new RaycastHit2D[3];
    RaycastHit2D[] wallHit = new RaycastHit2D[6];

    LayerMask groundMask;


    // Use this for initial8lization
    void Start () {
        groundMask = LayerMask.GetMask("Ground");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        isGrounded = GroundCast();
        WallCast();
	}

    //This method creates and displays Raycasts to detect ground under the player
    bool GroundCast() {

        //We need to clear the array everytime loop
        Array.Clear(groundHit, 0, 3);

        //Cast rays and store hit info in groundHit array
        groundHit[1] = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + 0.1f), Vector2.down, 0.2f, groundMask);
        groundHit[2] = Physics2D.Raycast(new Vector2(transform.position.x + 0.5f, transform.position.y + 0.1f), Vector2.down, 0.2f, groundMask);
        groundHit[0] = Physics2D.Raycast(new Vector2(transform.position.x - 0.5f, transform.position.y + 0.1f), Vector2.down, 0.2f, groundMask);


        int loop = 0;
        foreach (RaycastHit2D hit in groundHit) {
            if (hit.transform != null) {
                //TEST: see if array defualts as NULL before hitting object
                Debug.Log("Normal of hit " + loop + "" + hit.normal);

                return true;
            }

            loop++;

            //Displays rays
            Debug.DrawRay(new Vector2(transform.position.x, transform.position.y + 0.1f), Vector2.down * 0.2f);
            Debug.DrawRay(new Vector2(transform.position.x + 0.5f, transform.position.y + 0.1f), Vector2.down * 0.2f);
            Debug.DrawRay(new Vector2(transform.position.x - 0.5f, transform.position.y + 0.1f), Vector2.down * 0.2f);
        }
        return false;
    }

    //This method creates and displays Raycasts to detect if there's a wall infornt of the player
    void WallCast() {
        wallHit[0] = Physics2D.Raycast(new Vector2(transform.position.x + 0.5f, transform.position.y), Vector2.right, 0.2f, groundMask);
        wallHit[1] = Physics2D.Raycast(new Vector2(transform.position.x + 0.5f, transform.position.y + 0.5f), Vector2.right, 0.2f, groundMask);
        wallHit[2] = Physics2D.Raycast(new Vector2(transform.position.x + 0.5f, transform.position.y + 1f), Vector2.right, 0.2f, groundMask);

        foreach (RaycastHit2D hit in wallHit) {
            if (hit.transform != null) {
                //TEST: see if array defualts as NULL before hitting object
                Debug.Log("Normal wall hit " + hit.normal);
            }

            //Displays rays
        }

        Debug.DrawRay(new Vector2(transform.position.x + 0.5f, transform.position.y), Vector2.right * 0.2f);
        Debug.DrawRay(new Vector2(transform.position.x + 0.5f, transform.position.y + 0.5f), Vector2.right * 0.2f);
        Debug.DrawRay(new Vector2(transform.position.x + 0.5f, transform.position.y + 1f), Vector2.right * 0.2f);
    }
}
    