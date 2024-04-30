using System;
using UnityEngine;

public class Movement : MonoBehaviour {

    public bool isPressingRight;
    public bool isPressingLeft;
    public bool isRotatingRight;
    public bool isRotatingLeft;
    public bool isThrusting;

    private void Start() {
        
    }

    private void Update() {
        ProcessInputs();
    }

    private void ProcessInputs() {
        // basics
        isThrusting = Input.GetKey(KeyCode.Space);
        isPressingLeft = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        isPressingRight = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);

        // dynamics
        isRotatingLeft = !isRotatingRight && isPressingLeft;
        isRotatingRight = !isRotatingLeft && isPressingRight;
    }
}