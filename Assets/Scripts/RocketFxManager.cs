using System.Collections.Generic;
using UnityEngine;

public class RocketFxManager : MonoBehaviour {
    [SerializeField] AudioSource engineSFX, successSFX;

    [SerializeField] List<ParticleSystem> leftThrustersFX, rightThrustersFX;
    [SerializeField] ParticleSystem engineFX, successFX, explosionFX;

    public void HandlePlaySuccessParticleFX() {
        if (!successFX.isPlaying) successFX.Play();
    }

    public void HandlePlayExplosionParticleFX() {
        if (!explosionFX.isPlaying) explosionFX.Play();
    }

    public void HandlePlayEngineParticleFX() {
        if (!engineFX.isPlaying) engineFX.Play();
    }

    public void HandleStopEngineParticleFX() {
        if (engineFX.isPlaying) engineFX.Stop();
    }

    public void HandlePlayLeftThrustersParticleFX() {
        foreach (ParticleSystem leftThruster in leftThrustersFX) {
            if (!leftThruster.isPlaying) leftThruster.Play();
        }
    }

    public void HandleStopLeftThrustersParticleFX() {
        foreach (ParticleSystem leftThruster in leftThrustersFX) {
            if (leftThruster.isPlaying) leftThruster.Stop();
        }
    }

    public void HandlePlayRightThrustersParticleFX() {
        foreach (ParticleSystem rightThruster in rightThrustersFX) {
            if (!rightThruster.isPlaying) rightThruster.Play();
        }
    }
    
    public void HandleStopRightThrustersParticleFX() {
        foreach (ParticleSystem rightThruster in rightThrustersFX) {
            if (rightThruster.isPlaying) rightThruster.Stop();
        }
    }

    public void HandlePlayThrustSFX() {
        if (!engineSFX.isPlaying) {
            engineSFX.Play();
        }
    }

    public void HandleStopThrustSFX() {
        if (engineSFX.isPlaying) {
            engineSFX.Stop();
        }
    }

    public void HandlePlaySuccessSFX() {
        if (!successSFX.isPlaying) {
            successSFX.Play();
        }
    }
}