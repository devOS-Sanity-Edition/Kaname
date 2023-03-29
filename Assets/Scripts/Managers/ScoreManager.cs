using UnityEngine;

public class ScoreManager : MonoBehaviour {
    public static ScoreManager scoreManager;

    public int level;
    public int record;
    public int deaths;

    void Start() {
        scoreManager = this;
    }

    public void PlayerWin() {
        level++;
    }

    public void PlayerDeath() {
        if (level - 1 > record) { record = level - 1; }

        deaths++;
        level = 0;
    }
}