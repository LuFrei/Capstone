using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

//SRPING CLEANING CHECK LIST:
//[ ]Move Player management OUTTA 'ERE and into Level manager
//[ ]Move Spawn system management OUTTA 'ERE and probably into Level manager
//[ ]Same thing with the level ending
//

public class GameManager : MonoBehaviour {

	public delegate void LevelChangeAction();
	public static event LevelChangeAction OnLevelChanged;

    public enum GameState {Live, Paused};
    public GameState currentState;

	public int currentScene;

	public bool levelEnding = false;
 
    void Start () {
        //Upon start up, the game will default to the Title screen
        currentState = GameState.Live;

		//FOR TESTING: opens scene on start up based on propery
		//ON A PROPER BUILD THIS SHOULD BE SET TO 0
		GoToLevel(currentScene);
	}
	
 
	void Update () {
		//"Restarts" game
		if (Input.GetKeyDown(KeyCode.Escape)) {
			GoToLevel(1);
		}
	}

	
	public void GoToLevel(int level) {
		levelEnding = false;
		if(OnLevelChanged != null) {
			OnLevelChanged();
		}
		SceneManager.LoadScene(level);
	}
}
