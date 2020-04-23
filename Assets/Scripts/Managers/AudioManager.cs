using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public GameManager gameManager;

    AudioSource musicSource;
    public AudioClip[] musicClips;

    float timeKeeper = 4;
    bool readyToSwitch;

	// Use this for initialization
	void Start () {
        musicSource = GetComponent<AudioSource>();
        musicSource.clip = musicClips[1];
        musicSource.Play();
	}

    //// Update is called once per frame
    //void Update() {
    //    BeatCalculator();

    //    //for showing off Audio:
        

    //}

    void BeatCalculator(/*Might want an adjustable beat later on */) {
        //current beat is 120BPM
        //which starnslates to 2 BPS
        //every 2 seconds is a whole whole staff

        //This makes sure that after the frame it's ready to switch, it goes back to not ready, and wait for the next chunk to finish
        if (readyToSwitch) {
            readyToSwitch = false;
        }

        timeKeeper -= Time.deltaTime;

        if(timeKeeper <= 0) {
            readyToSwitch = true;
            timeKeeper = 4;
        }

    }
}
