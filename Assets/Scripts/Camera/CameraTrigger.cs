﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour {

    public CameraManagement camManage;
    public int roomNumber;

    private void Start() {
        camManage = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraManagement>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            camManage.currentPos = roomNumber;
        }
    }
}
