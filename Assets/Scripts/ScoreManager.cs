using UnityEngine;

public class ScoreManager : MonoBehaviour {
    public static ScoreManager scoreManager;

    public int level;
    public int record;
    public int deaths;
    
    void Start() {
        scoreManager = this;
    }

    void Update() {
        Debug.Log($"Level: {level}");
        // for some fucking reason it shows the accurate score but also 0 in the next line???? what???????????? ok sure
        // pain.
    }

    public void PlayerWin() {
        level++;
    }

    public void PlayerDeath() {
        if (level - 1 > record) {
            record = level - 1;
        }
        deaths++;
        level = 0;
    }
    
}
