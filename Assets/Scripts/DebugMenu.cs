using ImGuiNET;
using System.Collections;
using UnityEngine;
using FMOD;
using Unity.Profiling;

public class DebugMenu : MonoBehaviour {
    bool m_WindowEnabled = false;
    private float fpsCount;
    public GameObject cannon;
    
    private IEnumerator Start()
    {
        GUI.depth = 2;
        while (true)
        {
            fpsCount = 1f / Time.unscaledDeltaTime;
            yield return new WaitForSeconds(0.1f);
        }
    }
    void OnEnable() {
        ImGuiUn.Layout += OnLayout;
    }

    void OnDisable() {
        ImGuiUn.Layout -= OnLayout;
    }

    void ShowDebugView() {
        // ProfilerRecorder gfxTime = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Gfx.PresentFrame");
        if (!ImGui.Begin("Hikaru Debug",
                ref m_WindowEnabled,
                ImGuiWindowFlags.NoMove))
            return;
        ImGui.SetWindowPos(new Vector2(10, 120));
        ImGui.SetWindowSize(new Vector2(300, 200));
        ImGui.Text($"FPS: {Mathf.Round(fpsCount)}");
        // ImGui.Text($"GPU Frame Time: {gfxTime.LastValue}"); // TODO: not func atm, will look into CPU and GPU timings later
        ImGui.Text($"Screen Size: {Screen.width} x {Screen.height}");
        ImGui.Text($"Bullet Count: {bulletCount("Bullet")}");
        ImGui.Text($"Deathball Count: {bulletCount("Deathball")}");
        ImGui.Text($"Cannon Rotation {cannon.transform.eulerAngles.z}");
        ImGui.Text($"Timescale Speed: {Time.timeScale.ToString("#0.##%")}%");
    }

    void OnLayout() {
        ShowDebugView();
    }

    int bulletCount(string choice) {
        int count = 0;
        GameObject[] bullets = GameObject.FindGameObjectsWithTag(choice);
        foreach (GameObject bullet in bullets) {
            count++;
        }
        return count;
    }
}