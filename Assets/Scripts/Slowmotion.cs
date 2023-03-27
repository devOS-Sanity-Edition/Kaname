using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slowmotion : MonoBehaviour {
    void Update() {
        if (Input.GetKey("s")) {
            Time.timeScale = 0.4f;
        }
        else {
            Time.timeScale = 1f;
        }
    }
}
