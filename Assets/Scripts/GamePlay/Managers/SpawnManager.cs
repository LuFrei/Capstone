using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	//In this script, I want to manage all spawn in a scene and make sure only one
	//is ever on at a given time.

	//I want to keep a list that will update one scene change, and when player activates
	//a new spawner, deactivate all others.

	public List<Spawner> SpawnList;
	public Player player;

	private void Awake() { 
		// On awake, Make a list of all spawn point in scene
		GameObject[] spawnObjects = GameObject.FindGameObjectsWithTag("Respawn");
		foreach(GameObject spawn in spawnObjects) {
			SpawnList.Add(spawn.GetComponent<Spawner>());
		}

		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}

	//To set new spawn, I'll first turn all spawns off, and set input Spawn to new active spawn
	public void SetNewSpawn(GameObject newSpawn) {
		//get the Spawner script from GmObj
		Spawner spawner = newSpawn.GetComponent<Spawner>();

		//turn all spawns off (just in case)
		foreach(Spawner respawn in SpawnList) {
			respawn.active = false;
		}

		//set new spawner as current spawner
		spawner.active = true;
		player.currentSpawn = spawner.gameObject;

	}
}
