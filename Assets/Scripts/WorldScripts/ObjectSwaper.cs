using UnityEngine;

public class ObjectSwaper : MonoBehaviour {
    public GameObject swapTo;

    public void Swap() {
        GameObject rocket = GameObject.FindWithTag("Player");
        Instantiate(swapTo, rocket.transform.position, rocket.transform.rotation);
        Destroy(rocket);
    }
}