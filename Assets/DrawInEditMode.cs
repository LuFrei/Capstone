using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class DrawInEditMode : MonoBehaviour
{
	//stores vertex info for DrawLing
	private Vector2[] v = new Vector2[4];

	private void Update() {
		GetTransformInfo();
	}


	//Shows size and direction in edit mode
	void OnDrawGizmosSelected() {
		Gizmos.DrawLine(v[0], v[1]);
		Gizmos.DrawLine(v[1], v[2]);
		Gizmos.DrawLine(v[2], v[3]);
		Gizmos.DrawLine(v[3], v[0]);
	}

	void GetTransformInfo() {
		//Set Draw Vertexes
		//Size
		v[0] = new Vector2(transform.position.x - transform.localScale.x / 2, transform.position.y + transform.localScale.y / 2);
		v[1] = new Vector2(transform.position.x + transform.localScale.x / 2, transform.position.y + transform.localScale.y / 2);
		v[2] = new Vector2(transform.position.x + transform.localScale.x / 2, transform.position.y - transform.localScale.y / 2);
		v[3] = new Vector2(transform.position.x - transform.localScale.x / 2, transform.position.y - transform.localScale.y / 2);
	}
}
