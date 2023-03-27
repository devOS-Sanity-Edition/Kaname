using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

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

    void FixedUpdate() {
        deathCount.text = $"{Random.Range(1, 100)}";
        levelCount.text = $"{Random.Range(1, 100)}";
        recordCount.text = $"{Random.Range(1, 100)}";
    }
}
