using System;
using UnityEngine;

public class RocketMovement : MonoBehaviour {

    readonly float thrustForce = 1000f;
    readonly float rotationForce = 150f;
    readonly float zeroTolerance = 0.001f;
    public bool isPressingRight, isPressingLeft, isRotatingRight, isRotatingLeft, isThrusting, isSteady;
    Rigidbody rb;
    RocketCollision rocketCollision;
    RocketFxManager rocketFxManager;

    void Start() {
        rb = GetComponent<Rigidbody>();
        rocketCollision = GetComponent<RocketCollision>();
        rocketFxManager = GetComponent<RocketFxManager>();
    }

    void Update() {
        ProcessStateProperties();
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessStateProperties() {
        isThrusting = Input.GetKey(KeyCode.Space);
        isPressingLeft = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        isPressingRight = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);

        isRotatingLeft =  !isRotatingRight && isPressingLeft && !rocketCollision.isCollidingToAnything;
        isRotatingRight = !isRotatingLeft && isPressingRight &&  !rocketCollision.isCollidingToAnything;
        isSteady = GameObjIsResting();
    }

    void ProcessThrust() {
        if (isThrusting) {
            ApplyIndependentERelativeForce(thrustForce);
            rocketFxManager.HandlePlayThrustSFX();
            rocketFxManager.HandlePlayEngineParticleFX();
        } else {
            rocketFxManager.HandleStopThrustSFX();
            rocketFxManager.HandleStopEngineParticleFX();
        }
    }

    void ProcessRotation() {
        if (isRotatingRight) {
            ApplyIndependentRotation(-rotationForce);
            rocketFxManager.HandlePlayRightThrustersParticleFX();
        } else {
            rocketFxManager.HandleStopRightThrustersParticleFX();
        }

        if (isRotatingLeft) {
            ApplyIndependentRotation(rotationForce);
            rocketFxManager.HandlePlayLeftThrustersParticleFX();
        } else {
            rocketFxManager.HandleStopLeftThrustersParticleFX();
        }
    }

    void ApplyIndependentRotation(float rotation) {
        rb.freezeRotation = true;
        transform.Rotate(rotation * Time.deltaTime * Vector3.forward);
        rb.freezeRotation = false;
    }

    void ApplyIndependentERelativeForce(float force) {
        rb.AddRelativeForce(force * Time.deltaTime * Vector3.up);
    }

    public bool GameObjIsResting() {
        bool isAxisXSteady = Mathf.Abs(transform.eulerAngles.x) < zeroTolerance;
        bool isAxisZSteady = Mathf.Abs(transform.eulerAngles.z) < zeroTolerance;

        return isAxisXSteady && isAxisZSteady;
    }
}