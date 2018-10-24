using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    enum GameStates {Running, Paused, Finished};
    GameStates currentGameState;

    public GameObject pauseUI;

	// Use this for initialization
	void Start () {
        currentGameState = GameStates.Running;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)){
            switch (currentGameState) {
                case GameStates.Running:
                    currentGameState = GameStates.Paused;
                    break;
                case GameStates.Paused:
                    currentGameState = GameStates.Running;
                    break;
            }
        }

        switch (currentGameState) {
            case GameStates.Paused:
                pauseUI.SetActive(true);
                Time.timeScale = 0;
                PauseControls();
                break;
            case GameStates.Running:
                pauseUI.SetActive(false);
                Time.timeScale = 1;
                break;
        }
	}

    void PauseControls() {
        if (Input.GetKeyDown(KeyCode.Backspace)) {
            Debug.Log("App should have exited.");
            Application.Quit();
        }
    }
}
