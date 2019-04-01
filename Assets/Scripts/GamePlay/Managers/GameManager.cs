using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public enum GameStatus { Title, Running, Paused};
    public GameStatus currentState;

    public GameObject player; 

    public Transform currentRespawn;

    public GameObject titleScreen;
    public GameObject pauseScreen;

	public bool levelEnding = false;
 
    void Start () {
        //Upon start up, the game will default to the Title screen
        currentState = GameStatus.Title;
	}
	
 
	void Update () {
        //if player dies, play death loop
        //switch (currentState) {
        //    case GameStatus.Title:
        //        TitleLoop();
        //         break;
        //    case GameStatus.Running:
        //        RunningLoop();
        //        break;
        //    case GameStatus.Paused: 
        //        PauseLoop();
        //        break;
        //}

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            GoToLevel(0);
        }
		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			GoToLevel(1);
		}
		if (Input.GetKeyDown(KeyCode.Alpha3)) {
			GoToLevel(2);
		}
	}

	
	public void GoToLevel(int level) {
		levelEnding = false;
		SceneManager.LoadScene(level);
	}

	//void TitleLoop() {
	//    if (Input.GetKeyDown(KeyCode.Space)) {
	//        titleScreen.SetActive(false);
	//        currentState = GameStatus.Running;
	//    }
	//}

	//void RunningLoop() {
	//    if(player.GetComponent<Player>().playerDead == true) {
	//        Debug.Log("Death Loop Start");
	//        player.GetComponent<Player>().playerDead = false;
	//        StartCoroutine("DeathLoop");
	//    }

	//    //pause
	//    if (Input.GetKeyDown(KeyCode.Escape)) {
	//        currentState = GameStatus.Paused;
	//        pauseScreen.SetActive(true);
	//        Time.timeScale = 0;
	//    }
	//}

	//IEnumerator DeathLoop() {
	//    float timer = 2;


	//    while (timer > 0) {
	//        Debug.Log("Spawn Timer: " + timer);
	//        timer -= Time.deltaTime;
	//        yield return null;
	//    }

	//    player.transform.position = currentRespawn.position;

	//    Debug.Log("Player spawn");
	//}

	//void pauseloop() {

	//	//unpause
	//	if (input.getkeydown(keycode.escape)) {
	//		currentstate = gamestatus.running;
	//		pausescreen.setactive(false);
	//		time.timescale = 1;
	//	}

	//	//back to title
	//	if (input.getkeydown(keycode.backspace)) {
	//		scenemanager.loadscene(0);
	//		time.timescale = 1;
	//	}
	//}
}
