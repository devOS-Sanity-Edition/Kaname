using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonColor : MonoBehaviour {
    private SpriteRenderer cannonColor;
    private GameObject cannonObject;
    void Start() {
        GameColorManager.Theme theme = GameObject.Find("GameColorManager").GetComponent<GameColorManager>().InternalGameTheme;

        cannonColor = GetComponent<SpriteRenderer>();
        cannonColor.color = ColorHandler.GetColorFromString(theme.GameColors.Cannon);
    }
}
