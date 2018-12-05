﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public enum GameStatus { Title, Running, Paused};
    public GameStatus currentState;

    public GameObject player; 

    public bool playerDead = true;
    public Transform currentRespawn;

    public GameObject titleScreen;
    public GameObject pauseScreen;

    // Use this for initialization
    void Start () {
        currentState = GameStatus.Title;
	}
	
	// Update is called once per frame
	void Update () {
        //if player dies, play death loop
        switch (currentState) {
            case GameStatus.Title:
                TitleLoop();
                break;
            case GameStatus.Running:
                RunningLoop();
                break;
            case GameStatus.Paused:
                PauseLoop();
                break;
        }



	}

    void TitleLoop() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            titleScreen.SetActive(false);
            currentState = GameStatus.Running;
        }
    }

    void RunningLoop() {
        if(playerDead == true) {
            Debug.Log("Death Loop Start");
            playerDead = false;
            StartCoroutine("DeathLoop");
        }

        //pause
        if (Input.GetKeyDown(KeyCode.Escape)) {
            currentState = GameStatus.Paused;
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    IEnumerator DeathLoop() {
        float timer = 2;
            

        while (timer > 0) {
            Debug.Log("Spawn Timer: " + timer);
            timer -= Time.deltaTime;
            yield return null;
        }

        player.transform.position = currentRespawn.position;

        Debug.Log("Player spawn");
    }

    void PauseLoop() {

        //Unpause
        if (Input.GetKeyDown(KeyCode.Escape)) {
            currentState = GameStatus.Running;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }

        //back to title
        if (Input.GetKeyDown(KeyCode.Backspace)) {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }
    }
}