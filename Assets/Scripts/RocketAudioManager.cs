using UnityEngine;

public class RocketAudioManager : MonoBehaviour {
    AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void HandlePlayThrust() {
        if (!audioSource.isPlaying) {
            audioSource.Play();
        }
    }

    public void HandleStopThrust() {
        if (audioSource.isPlaying) {
            audioSource.Stop();
        }
    }
}