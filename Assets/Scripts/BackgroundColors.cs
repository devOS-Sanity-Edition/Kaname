using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColors : MonoBehaviour {
    void Start() {
        GameColorManager.Theme theme = GameObject.Find("GameColorManager").GetComponent<GameColorManager>().InternalGameTheme;
        
        Camera cameraObject = GameObject.Find("GameCamera").GetComponent<Camera>();
        cameraObject.backgroundColor = ColorHandler.GetColorFromString(theme.UIColors.Background);

        GameObject backgroundCircleObject = GameObject.Find("BackgroundCircle");
        SpriteRenderer backgroundCircleColor = backgroundCircleObject.GetComponent<SpriteRenderer>();
        backgroundCircleColor.color = ColorHandler.GetColorFromString(theme.GameColors.BackgroundCircle);
    }

    // Update is called once per frame
    void Update() {
        
    }
}
