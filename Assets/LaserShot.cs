using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShot : MonoBehaviour {

    float maxLength = 100;

    private LineRenderer line;
    private Transform direction;
    private float length;

    LayerMask rayMask;

    //stores vertecies of the line
    private Vector3[] lineCoords = new Vector3[2];

	// Use this for initialization
	void Start () {
        line = GetComponent<LineRenderer>();
        rayMask = (1 << 11);
        rayMask = ~rayMask;
    }
	
	// Update is called once per frame
	void Update () {
        //check GameObject position everyframe to update origin.
        for (int i = 0; i < lineCoords.Length; i++){
            lineCoords[i] = transform.position;
        }
        CastRay();
        DrawLine();
	}

    void CastRay() {

        //casts Ray from origin point, downwards.
        RaycastHit2D hit = Physics2D.Raycast(lineCoords[0], new Vector2(0, -1), maxLength, rayMask);

        //if Ray hit something, set length to Ray distance,
        //else, default to maxlength
        length = hit ? hit.distance : maxLength;
        
        //Set length to end Coordinate
        lineCoords[1] = new Vector3(lineCoords[1].x, transform.position.y - length);

        //Draw debug visuals
        Debug.DrawRay(lineCoords[0], new Vector2(0, -1 * length), Color.red);
    }

    void DrawLine() {
        line.SetPositions(lineCoords);
    }

}
