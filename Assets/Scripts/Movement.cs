using System;
using UnityEngine;

public class Movement : MonoBehaviour {

    public bool isPressingRight;
    public bool isPressingLeft;
    public bool isRotatingRight;
    public bool isRotatingLeft;
    public bool isThrusting;
    public float thrustForce = 1000f;
    public float rotationForce = 100f;
    public Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        ProcessInputs();
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessInputs() {
        isThrusting = Input.GetKey(KeyCode.Space);
        isPressingLeft = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        isPressingRight = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);

        isRotatingLeft =  !isRotatingRight && isPressingLeft;
        isRotatingRight = !isRotatingLeft && isPressingRight;
    }

    void ProcessThrust() {
        if (isThrusting) {
            rb.AddRelativeForce(Vector3.up * GetIndependentThrust());
        }
    }

    void ProcessRotation() {
        if (isRotatingRight) {
            transform.Rotate(Vector3.forward * GetInvertedIndependentRotation());
        }

        if (isRotatingLeft) {
            transform.Rotate(Vector3.forward * GetIndependentRotation());
        }
    }

    float GetIndependentThrust() {
        return thrustForce * Time.deltaTime;
    }

    float GetIndependentRotation() {
        return rotationForce * Time.deltaTime;   
    }

    float GetInvertedIndependentRotation() {
        return -GetIndependentRotation();   
    }
}