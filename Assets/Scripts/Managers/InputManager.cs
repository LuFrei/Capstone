using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  
public class InputManager{

    public float xAxis;
    public float yAxis;
    public bool fire;
    public bool jump;

    GameManager gameManager;
    PlayerController player;


    void Update() {
        xAxis = Input.GetAxisRaw("Horizontal");
        yAxis = Input.GetAxisRaw("Vertical");
        fire = Input.GetButtonDown("Fire");
        jump = Input.GetButtonDown("Jump");
    }
}
