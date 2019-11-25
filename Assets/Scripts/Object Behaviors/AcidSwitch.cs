using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidSwitch : MonoBehaviour
{
	//LEGACY SPAGHETTI
	//This will be changed so that the switch will contain the the function of turning things on or off.
	public Switch aSwitch;  //switch this class will use

	private void Update() {
		//When reference switch is turned on, drain acid
		if (aSwitch.on) {
			gameObject.active = false;
		}
	}
}
