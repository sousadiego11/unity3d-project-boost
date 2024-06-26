using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketCollision : MonoBehaviour {
    public bool isCollidingToAnything = false;
    public bool crashed = false;
    RocketMovement rocket;
    GameObject scripts;
    SceneManagerInternal sceneManager;
    ObjectSwaper objSwaper;
    RocketFxManager rocketFxManager;

    void Start() {
        rocket = GetComponent<RocketMovement>();   
        scripts = GameObject.FindWithTag("Scripts");
        sceneManager = scripts.GetComponent<SceneManagerInternal>();
        objSwaper = scripts.GetComponent<ObjectSwaper>();
        rocketFxManager = GetComponent<RocketFxManager>();
    }

    void OnCollisionStay(Collision other) {
        isCollidingToAnything = true;
        if (other.gameObject.CompareTag("Finish")) {
            HandleFinish();
        }
        
    }

    void OnCollisionEnter(Collision other) {
        isCollidingToAnything = true;
        if (other.gameObject.CompareTag("Obstacle") && !crashed) {
            HandleCrash();
        }
    }

    void OnCollisionExit(Collision other) {
        isCollidingToAnything = false;    
    }

    void HandleFinish() {
        if (rocket.isSteady) {
            float delaySeconds = 2f;
            rocketFxManager.HandlePlaySuccessSFX();
            rocketFxManager.HandlePlaySuccessParticleFX();
            
            if (!sceneManager.GetIsLastScene()) sceneManager.AdvanceDelay(delaySeconds);
        }
    }

    void HandleCrash() {
        float delaySeconds = 4f;
        crashed = true;
        sceneManager.ReloadDelay(delaySeconds);
        objSwaper.Swap();
    }
}
