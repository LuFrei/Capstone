using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {

    public float _input;
    public float _varA;
    public float _output;

    private void Start() {

    }

    private void Update() {
        _output = Function(_input, _varA);
        Debug.Log("Function's out put is: " + _output);
        Debug.Log("Base _VarA should be: " + _varA);
    }

    float Function(float input, float varA) {
        if (Input.GetKey(KeyCode.M)) {
            varA = -varA;
        }
        Debug.Log("Function varA should be: " + varA);
        _varA = varA;

        input += 5;
        return input;
    }
}
