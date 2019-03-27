using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryAfter : MonoBehaviour
{
	//simple script im throwing up to destory moving platform after it reachs a certain Y value
	//Could probably be edited for mutli purpose later.

	public float yThreshold;

	private void Update() {
		if(gameObject.transform.position.y > yThreshold) {
			Destroy(gameObject);
		}
	}
}
