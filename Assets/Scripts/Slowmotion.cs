using UnityEngine;

public class Slowmotion : MonoBehaviour {
    void Update() {
        if (Input.GetKey("s")) {
            Time.timeScale = 0.25f;
        }
        else {
            Time.timeScale = 1f;
        }
    }
}
