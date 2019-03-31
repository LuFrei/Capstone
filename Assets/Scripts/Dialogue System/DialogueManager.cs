using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
	//coresponds with the ugly code i made in PC to stop movememnt during dialogue
	public PlayerController player;

	public Text nameText;
	public Text dialogueText;

	public Animator anim;

	public bool active;

	//keeps track of all sentences of current dialogue
	private Queue<string> sentences;

    void Start()    {
		sentences = new Queue<string>();
		player = FindObjectOfType<PlayerController>();
    }

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			DisplayNextSentence();
		}
	}

	public void StartDialogue (Dialogue dialogue) {
		active = true;
		anim.SetBool("IsOpen", true);
		player.inDialogue = true;

			sentences.Clear(); //Queue.Clear() clears everything from the Queue

			//load new sentences to Queue
			foreach (string sentence in dialogue.sentences) {
				sentences.Enqueue(sentence);//Queue.Enqueue adds object to the Queue.
			}

			DisplayNextSentence();
	}

	//This plisplays next sentence in Queue
	public void DisplayNextSentence() {
		//Checks to see IF there is any more sentences left
		if(sentences.Count == 0) {
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();//Queue.Dequeue removes, AND returns the object in the BEGINNING of the queue
		dialogueText.text = sentence;
	}

	private void EndDialogue() {
		active = false;
		anim.SetBool("IsOpen", false);
		player.inDialogue = false;
	}
}
