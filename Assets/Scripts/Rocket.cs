using System;
using UnityEngine;

public class Rocket : MonoBehaviour {

    readonly float thrustForce = 1000f;
    readonly float rotationForce = 100f;
    readonly float zeroTolerance = 0.1f;
    public bool isPressingRight, isPressingLeft, isRotatingRight, isRotatingLeft, isThrusting, isSteady;
    Rigidbody rb;
    AudioSource audioS;
    RocketCollision rocketCollision;

    void Start() {
        rb = GetComponent<Rigidbody>();
        audioS = GetComponent<AudioSource>();
        rocketCollision = GetComponent<RocketCollision>();
    }

    void Update() {
        ProcessBooleans();
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessBooleans() {
        isThrusting = Input.GetKey(KeyCode.Space);
        isPressingLeft = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        isPressingRight = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);

        isRotatingLeft =  !isRotatingRight && isPressingLeft && !rocketCollision.isColliding;
        isRotatingRight = !isRotatingLeft && isPressingRight &&  !rocketCollision.isColliding;
        isSteady = Mathf.Abs(transform.eulerAngles.x) < zeroTolerance || Mathf.Abs(transform.eulerAngles.x) < zeroTolerance;
    }

    void ProcessThrust() {
        if (isThrusting) {
            rb.AddRelativeForce(thrustForce * Time.deltaTime * Vector3.up);
            if (!audioS.isPlaying) {
                audioS.Play();
            }
        } else {
            if (audioS.isPlaying) {
                audioS.Stop();
            }
        }
    }

    void ProcessRotation() {
        if (isRotatingRight) {
            ApplyIndependentRotation(-rotationForce);
        }

        if (isRotatingLeft) {
            ApplyIndependentRotation(rotationForce);
        }
    }

    void ApplyIndependentRotation(float rotation) {
        rb.freezeRotation = true;
        transform.Rotate(rotation * Time.deltaTime * Vector3.forward);
        rb.freezeRotation = false;
    }
}