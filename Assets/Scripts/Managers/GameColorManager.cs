using System;
using System.IO;
using UnityEngine;

public class GameColorManager : MonoBehaviour {
    // public Camera gameCamera;

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


    void Start() {
        string developmentJSONFile = File.ReadAllText(developmentThemeJSON);

        InternalGameTheme = JsonUtility.FromJson<Theme>(developmentJSONFile);
    }
}
