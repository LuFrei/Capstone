using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{


	//LEGACY SPAGHETTI - These scripts are to be rewrittenand/or thown out!
	//Like AcidSwitch, This will be handled by a function in 'Switch'
	public Switch dSwitch;  //switch this class will use
	public DoorBehavior door;



	private void Update() {
		//When reference switch is turned on, open door.
		if (dSwitch.on) {
			StartCoroutine(door.Open());
		}
	}
}
