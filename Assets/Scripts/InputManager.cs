using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager{

    public static float _xAxis = Input.GetAxisRaw("Horizontal");
    public static float _yAxis = Input.GetAxisRaw("Vertical");
    public static bool _fire = Input.GetButtonDown("Fire");
    public static bool _jump = Input.GetButtonDown("Jump");


}
