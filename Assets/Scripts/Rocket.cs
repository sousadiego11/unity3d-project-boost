using System;
using UnityEngine;

public class Rocket : MonoBehaviour {

    public bool isPressingRight;
    public bool isPressingLeft;
    public bool isRotatingRight;
    public bool isRotatingLeft;
    public bool isThrusting;
    public float thrustForce = 1000f;
    public float rotationForce = 100f;
    public Rigidbody rb;
    public AudioSource audioS;

    void Start() {
        rb = GetComponent<Rigidbody>();
        audioS = GetComponent<AudioSource>();
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
            rb.AddRelativeForce(Vector3.up * thrustForce * Time.deltaTime);
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