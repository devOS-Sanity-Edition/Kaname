using FMODUnity;
using UnityEngine;

public class DeathBall : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Bullet") {
            RuntimeManager.PlayOneShot("event:/SFX/Damage"); GameObject.Find("ScoreManager").GetComponent<ScoreManager>().PlayerDeath();
            Destroy(col.gameObject);
        }
    }
}