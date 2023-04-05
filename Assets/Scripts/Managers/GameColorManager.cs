using System;
using System.IO;
using UnityEngine;

public class GameColorManager : MonoBehaviour {
    Color gameBackgroundColor;
    Color gameBackgroundCircleColor;
    Color gameBulletColor;
    Color gameCannonColor;
    Color gameDeathFlashColor;
    Color gameObstacleLayer1Color;
    Color gameObstacleLayer2Color;
    Color gameObstacleLayer3Color;
    Color gameObstacleLayer4Color;
    Color uiBackgroundColor;
    Color uiLabelColor;
    Color uiLabelNumericColor;


    string developmentThemeJSON = $"{Application.streamingAssetsPath}/GameData/Themes/Default/Development/theme.json";

    [Serializable]
    public class Theme {
        public GameColors GameColors;
        public UIColors UIColors;
    }

    [Serializable]
    public class GameColors {
        public string Background;
        public string BackgroundCircle;
        public string Bullet;
        public string Cannon;
        public string DeathFlash;
        public string ObstacleLayer1;
        public string ObstacleLayer2;
        public string ObstacleLayer3;
        public string ObstacleLayer4;
    }

    [Serializable]
    public class UIColors {
        public string Background;
        public string Label;
        public string LabelNumeric;
    }

    public Theme InternalGameTheme = new Theme();
    
    void Awake() {
        string developmentJSONFile = File.ReadAllText(developmentThemeJSON);

        InternalGameTheme = JsonUtility.FromJson<Theme>(developmentJSONFile);
    }
}
