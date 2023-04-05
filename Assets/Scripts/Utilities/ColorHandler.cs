using System;
using UnityEngine;

public class ColorHandler : MonoBehaviour {
    public static int HexToDec(string hex) {
        int dec = Convert.ToInt32(hex, 16);
        return dec;
    }

    public static float HexToFloatNormalized(string hex) {
        return HexToDec(hex)/255f;
    }

    public static Color GetColorFromString(string hexString) {
        float red = HexToFloatNormalized(hexString.Substring(0, 2));
        float green = HexToFloatNormalized(hexString.Substring(2, 2));
        float blue = HexToFloatNormalized(hexString.Substring(4, 2));
        float alpha = 1f;
        if (hexString.Length >= 8) {
            alpha = HexToFloatNormalized(hexString.Substring(6, 2).ToUpper());
        }

        return new Color(red, green, blue, alpha);
    }
}
