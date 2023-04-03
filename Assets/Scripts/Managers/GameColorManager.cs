using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering;

public class GameColorManager : MonoBehaviour {
    // public Camera gameCamera;

    string developmentThemeJSON = $"{Application.streamingAssetsPath}/GameData/Themes/Default/Development/theme.json";
    
    [System.Serializable]
    public class GameColors {
        public string Background;
        public string BackgroundCircle;
        public string Bullet;
        public string Cannon;
        public string ObstacleLayer1;
        public string ObstacleLayer2;
        public string ObstacleLayer3;
        public string ObstacleLayer4;
    }

    [System.Serializable]
    public class UIColors {
        public string Background;
        public string Label;
        public string LabelNumeric;
    }

    [System.Serializable]
    public class GameColorsList {
        public GameColors[] GameColors;
    }

    [System.Serializable]
    public class UIColorsList {
        public UIColors[] UIColors;
    }

    public GameColorsList InternalGameColorsList = new GameColorsList();
    public UIColorsList InternalUIColorsList = new UIColorsList();


    void Start() {
        string developmentJSONFile = File.ReadAllText(developmentThemeJSON);
        InternalGameColorsList = JsonUtility.FromJson<GameColorsList>(developmentJSONFile);
        InternalUIColorsList = JsonUtility.FromJson<UIColorsList>(developmentJSONFile);
    }
}

