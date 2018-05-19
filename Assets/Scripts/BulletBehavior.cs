using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

	public float _speed;
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Translate(Vector3.right * _speed * Time.deltaTime);
	}

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
