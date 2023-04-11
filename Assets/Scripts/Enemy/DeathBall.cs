using System;
using FMODUnity;
using UnityEngine;

public class DeathBall : MonoBehaviour {
    private SpriteRenderer deathBallRenderer;

    private void Start() {
        GameColorManager.Theme theme = GameObject.Find("GameColorManager").GetComponent<GameColorManager>().InternalGameTheme;
        deathBallRenderer = GetComponent<SpriteRenderer>();
        deathBallRenderer.color = ColorHandler.GetColorFromString(theme.GameColors.ObstacleLayer1);
    }
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Bullet") {
            RuntimeManager.PlayOneShot("event:/SFX/Damage"); GameObject.Find("ScoreManager").GetComponent<ScoreManager>().PlayerDeath();
            Destroy(col.gameObject);
        }
    }
}