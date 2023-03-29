using UnityEngine;

public class BallScore : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other) {
        // ScoreManager.scoreManager.PlayerWin();
        GameObject.Find("ScoreManager").GetComponent<ScoreManager>().PlayerWin();
        Destroy(this.gameObject);

    }
}