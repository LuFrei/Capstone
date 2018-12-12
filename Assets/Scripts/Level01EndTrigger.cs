using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level01EndTrigger : MonoBehaviour {

    bool isActive = false;
    public GameObject gasEffect;
    Player player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isActive) {
            //Activate gas effects
            gasEffect.SetActive(true);
            //Damage player until dead
            if (player.playerDead) {
                SceneManager.LoadScene("Scene02");
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            isActive = true;
        }
    }
}
