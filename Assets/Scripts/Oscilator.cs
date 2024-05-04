using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscilator : MonoBehaviour {
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor;
    [SerializeField] float period;

    void Start() {
        startingPosition = transform.position;
    }

    void Update() {
        const float tau = Mathf.PI * 2; // Const of 6.28
        float cycles = Time.time / period; // Continually increasing
        float rawSinWave = Mathf.Sin(cycles * tau); // -1 to 1

        movementFactor = (rawSinWave + 1f) / 2f; // 0 to 1
        Vector3 newOffset = movementFactor * movementVector;
        Vector3 newPosition = startingPosition + newOffset; 

        transform.position = newPosition;
    }
}
