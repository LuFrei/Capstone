using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidSwitch : MonoBehaviour
{
	public Switch aSwitch;  //switch this class will use

	private void Update() {
		//When reference switch is turned on, drain acid
		if (aSwitch.on) {
			gameObject.active = false;
		}
	}
}
