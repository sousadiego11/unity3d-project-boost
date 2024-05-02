using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketCollision : MonoBehaviour {
    public bool isCollidingToAnything = false;
    public bool crashed = false;
    Rocket rocket;
    GameObject scripts;
    SceneManagerInternal sceneManager;
    ObjectSwaper objSwaper;

    void Start() {
        rocket = GetComponent<Rocket>();   
        scripts = GameObject.FindWithTag("Scripts");
        sceneManager = scripts.GetComponent<SceneManagerInternal>();
        objSwaper = scripts.GetComponent<ObjectSwaper>();
    }

    void OnCollisionStay(Collision other) {
        isCollidingToAnything = true;
        if (other.gameObject.CompareTag("Finish")) {
            HandleFinish();
        }
        
    }

    void OnCollisionEnter(Collision other) {
        isCollidingToAnything = true;
        if (other.gameObject.CompareTag("Obstacle")) {
            HandleCrash();
        }
    }

    void OnCollisionExit(Collision other) {
        isCollidingToAnything = false;    
    }

    void HandleFinish() {
        if (rocket.isSteady) {
            sceneManager.Advance();
        }
    }

    void HandleCrash() {
        float delaySeconds = 2f;
        crashed = true;
        sceneManager.ReloadDelay(delaySeconds);
        objSwaper.Swap();
    }
}
