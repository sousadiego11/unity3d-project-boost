using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerInternal : MonoBehaviour {
    public void Advance() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReloadDelay(float delaySeconds) {
        Invoke(nameof(Reload), delaySeconds);
    }

    public void Reload() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}