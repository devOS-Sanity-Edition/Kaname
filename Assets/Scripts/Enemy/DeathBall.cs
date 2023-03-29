using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBall : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Bullet") {
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Damage");
            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().PlayerDeath();
            Destroy(col.gameObject);
        }
    }
}