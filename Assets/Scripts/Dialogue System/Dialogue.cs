using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class will store a single sequence of dialogue to be passed into DialogueManager.
[System.Serializable] //This allows class to be seen in inspector.
public class Dialogue{

	//name of dialogue giver
	public string name;
	//sentences to be loaded into the Queue
	[TextArea(3, 10)]
	public string[] sentences;
}
