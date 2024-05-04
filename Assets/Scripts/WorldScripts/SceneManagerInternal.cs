using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerInternal : MonoBehaviour {

    public void ReloadDelay(float delaySeconds) {
        Invoke(nameof(Reload), delaySeconds);
    }

    public void AdvanceDelay(float delaySeconds) {
        Invoke(nameof(Advance), delaySeconds);
    }
    
    public void Advance() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Reload() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public bool GetIsLastScene() {
        return SceneManager.loadedSceneCount == SceneManager.GetActiveScene().buildIndex;
    }
}