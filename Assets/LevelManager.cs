using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	GameManager gm;

	//This will store events to happen during end sequence
	public int[] sequences; //CHANGE THE int PLACE HOLDER TYPE UNTIL I FIGURE IT OUT

    // Start is called before the first frame update
    void Start(){
		gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

	void Endevel() {
		gm.GoToLevel(1);
	}
}
