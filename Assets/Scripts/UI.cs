using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour {
    Label deathCount;
    Label levelCount;
    Label recordCount;


    void OnEnable() {
        var rootVisualElement = GetComponent<UIDocument>().rootVisualElement;

        deathCount = rootVisualElement.Q<Label>("DeathsCount");
        levelCount = rootVisualElement.Q<Label>("LevelCount");
        recordCount = rootVisualElement.Q<Label>("RecordCount");
    }

    void Update() {
        deathCount.text = $"{GameObject.Find("ScoreManager").GetComponent<ScoreManager>().deaths}";
        levelCount.text = $"{GameObject.Find("ScoreManager").GetComponent<ScoreManager>().level}";
        recordCount.text = $"{GameObject.Find("ScoreManager").GetComponent<ScoreManager>().record}";
    }
}