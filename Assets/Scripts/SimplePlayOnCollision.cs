using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayOnCollision : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Obstacle") && !audioSource.isPlaying) {
            audioSource.Play();    
        }
    }
}
