using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour {
    Label deathCount;
    Label levelCount;
    Label recordCount;

    Label deathLabel;
    Label levelLabel;
    Label recordLabel;

    VisualElement deathElement;
    VisualElement levelElement;
    VisualElement recordElement;

    Color deathCountColor;
    Color levelCountColor;
    Color recordCountColor;

    Color deathLabelColor;
    Color levelLabelColor;
    Color recordLabelColor;

    Color deathElementBackgroundColor;
    Color levelElementBackgroundColor;
    Color recordElementBackgroundColor;

    void OnEnable() {
        GameColorManager.Theme theme = GameObject.Find("GameColorManager").GetComponent<GameColorManager>().InternalGameTheme;
        VisualElement rootVisualElement = GetComponent<UIDocument>().rootVisualElement;


        deathCount = rootVisualElement.Q<Label>("DeathsCount");
        levelCount = rootVisualElement.Q<Label>("LevelCount");
        recordCount = rootVisualElement.Q<Label>("RecordCount");

        deathLabel = rootVisualElement.Q<Label>("DeathsLabel");
        levelLabel = rootVisualElement.Q<Label>("LevelLabel");
        recordLabel = rootVisualElement.Q<Label>("RecordLabel");

        deathElement = rootVisualElement.Q<VisualElement>("Death");
        levelElement = rootVisualElement.Q<VisualElement>("Level");
        recordElement = rootVisualElement.Q<VisualElement>("Record");

        deathCountColor = ColorHandler.GetColorFromString(theme.UIColors.LabelNumeric);
        levelCountColor = ColorHandler.GetColorFromString(theme.UIColors.LabelNumeric);
        recordCountColor = ColorHandler.GetColorFromString(theme.UIColors.LabelNumeric);
        
        deathLabelColor = ColorHandler.GetColorFromString(theme.UIColors.Label);
        levelLabelColor = ColorHandler.GetColorFromString(theme.UIColors.Label);
        recordLabelColor = ColorHandler.GetColorFromString(theme.UIColors.Label);

        deathElementBackgroundColor = ColorHandler.GetColorFromString(theme.UIColors.Background);
        levelElementBackgroundColor = ColorHandler.GetColorFromString(theme.UIColors.Background);
        recordElementBackgroundColor = ColorHandler.GetColorFromString(theme.UIColors.Background);

        
        deathCount.style.color = deathCountColor;
        levelCount.style.color = levelCountColor;
        recordCount.style.color = recordCountColor;
        
        deathLabel.style.color = deathLabelColor;
        levelLabel.style.color = levelLabelColor;
        recordLabel.style.color = recordLabelColor;

        deathElement.style.backgroundColor = new StyleColor(deathElementBackgroundColor);
        levelElement.style.backgroundColor = new StyleColor(levelElementBackgroundColor);
        recordElement.style.backgroundColor = new StyleColor(recordElementBackgroundColor);
    }

    void Update() {
        deathCount.text = $"{GameObject.Find("ScoreManager").GetComponent<ScoreManager>().deaths}";
        levelCount.text = $"{GameObject.Find("ScoreManager").GetComponent<ScoreManager>().level}";
        recordCount.text = $"{GameObject.Find("ScoreManager").GetComponent<ScoreManager>().record}";
    }
}