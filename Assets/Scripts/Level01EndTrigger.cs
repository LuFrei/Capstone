using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level01EndTrigger : MonoBehaviour {

	DialogueManager dm;
	GameManager gm;
    Player player;

	public int step = 0;
    public bool isActive = false;


	public DoorBehavior door1;
	public DoorBehavior door2;
	public DialogueTrigger dialogue1;

	public DoorBehavior hatch;
	public DoorBehavior acid;

	public DialogueTrigger dialogue2;

	public DialogueTrigger dialogue3;


	// Use this for initialization
	void Start () {
		dm = GameObject.FindGameObjectWithTag("GameController").GetComponent<DialogueManager>();
		gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player") && !isActive) {
            isActive = true;
			gm.levelEnding = true;
			NextSequence();
        }
    }

	private void Update() {
		//going to check for next step cue in here
		if (isActive) {
			//look for the cue specific to each step
			switch (step) {
				case 0: 
					if (!dm.active) {
						step++;
						NextSequence();
					}
					break;
				case 1:
					Debug.Log("Checking for open hatch");
					if (hatch.isOpen) {
						Debug.Log("hatch detected as open");
						step++;
						NextSequence();
					}
					break; 
				case 2:
					if (acid.isOpen) {
						step++;
						NextSequence();
					}
					break;
				case 3:
					if (!dm.active) {
						step++;
						NextSequence();
					}
					break;
				case 4:
					if (player.playerDead) {
						step++;
						NextSequence();
					}
					break;
				case 5:
					if (!dm.active) {
						step++;
						NextSequence();
					}
					break;
			}
		}
	}

	void NextSequence() {
		switch (step) {
			case 0:	//Lock Doors and start first dailogue
				StartCoroutine(door1.Close());
				StartCoroutine(door2.Close());
				dialogue1.TriggerDialogue();
				break;
			case 1:	//Open hatches
				StartCoroutine(hatch.Open());
				break;
			case 2: //flood room with acid (not damaging acid)
				StartCoroutine(acid.Open()); //using door behavior on it for simplicity
				break;
			case 3: //Second dialogue
				dialogue2.TriggerDialogue();
				break;
			case 4: //make player explode
				player.Damage(100, 0);
				break;
			case 5: //Final dialogue
				dialogue3.TriggerDialogue();
				break;
			case 6: //Exit Level
				gm.GoToLevel(1);
				break;
		}
	}
}
