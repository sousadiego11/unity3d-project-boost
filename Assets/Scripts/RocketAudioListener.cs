using UnityEngine;

public class RocketAudioListener : MonoBehaviour {
    AudioSource audioSource;
    RocketMovement rocket;

    void Start() {
        rocket = GetComponent<RocketMovement>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        if (rocket != null && rocket.isThrusting) {
            if (!audioSource.isPlaying) {
                audioSource.Play();
            }
        } else {
            if (audioSource.isPlaying) {
                audioSource.Stop();
            }
        }
    }
}