using System;
using System.IO;
using UnityEngine;

public class GameColorManager : MonoBehaviour {
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
        // TODO: After looking back at the mockups, the Balls need to be a separate color too, which isn't the case in old G4 [.1-.7] but is the case in what was previously `New G4` [.8]
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
