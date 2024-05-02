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

    void OnCollisionEnter(Collision other) {
        isColliding = true;
        switch (other.gameObject.tag) {
            case "Obstacle":
                HandleRespawn();
                break;
            case "Finish":
                HandleFinish();
                break;
        }
    }

    void OnCollisionExit(Collision other) {
        isColliding = false;    
    }

    void HandleFinish() {
    }

    void HandleRespawn() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
