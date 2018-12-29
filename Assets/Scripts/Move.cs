using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public enum Direction { Up, Down, Left, Right};
    public Direction direction;

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        switch (direction) {
            case Direction.Up:
                transform.Translate(Vector3.up * speed * Time.deltaTime);
                break;
            case Direction.Down:
                transform.Translate(Vector3.down * speed * Time.deltaTime);
                break;
            case Direction.Left:
                transform.Translate(Vector3.left * speed * Time.deltaTime);
                break;
            case Direction.Right:
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                break;
        }
	}
}
