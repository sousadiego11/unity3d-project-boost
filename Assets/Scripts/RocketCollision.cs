using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketCollision : MonoBehaviour {
    public bool isColliding = false;
    Rocket rocket;

    void Start() {
        rocket = GetComponent<Rocket>();    
    }

    void OnCollisionStay(Collision other) {
        isColliding = true;
        switch (other.gameObject.tag) {
            case "Finish":
                HandleFinish();
                break;
        }
        
    }

    void OnCollisionEnter(Collision other) {
        isColliding = true;
        switch (other.gameObject.tag) {
            case "Obstacle":
                HandleRespawn();
                break;
        }
    }

    void OnCollisionExit(Collision other) {
        isColliding = false;    
    }

    void HandleFinish() {
        if (rocket.isSteady) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void HandleRespawn() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
