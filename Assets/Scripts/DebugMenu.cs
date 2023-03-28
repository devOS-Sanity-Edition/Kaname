using ImGuiNET;
using System.Collections;
using UnityEngine;

public class DebugMenu : MonoBehaviour {
    bool m_WindowEnabled = false;
    private float fpsCount;
    public GameObject cannon;
    bool debugBuild;
    bool editorBuild;
    bool displayDebug; // todo: make this a toggle. make debug view not show by default in prod, but show by default in editor and dev/debug builds
    
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
        if (!ImGui.Begin("Hikaru Debug",
                ref m_WindowEnabled,
                ImGuiWindowFlags.NoMove))
            return;
        
        ImGui.Text($"FPS: {Mathf.Round(fpsCount)}");
        ImGui.Text($"Screen Size: {Screen.width} x {Screen.height}");

        if (ImGui.CollapsingHeader("Build")) {
            #if UNITY_EDITOR
                editorBuild = true;
            #endif
            ImGui.Text($"Editor Mode: {editorBuild.ToString()}");
            #if DEVELOPMENT_BUILD // IDES ARE GOING TO SAY THIS IS UNREACHABLE CODE! FALSE! THIS ACTUALLY DOES WORK IN DEVELOPMENT BUILDS BUT OF COURSE
                                  //
                                  // +
                                  //
                                  // 0+ +0 -
                                  // 0+  IT DOESNT KNOW THAT AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
                debugBuild = true;
            #endif
            ImGui.Text($"Debug Build: {debugBuild.ToString()}");
        }
        
        if (ImGui.CollapsingHeader("Game")) {
            ImGui.Text($"Bullet Count: {bulletCount("Bullet")}");
            ImGui.Text($"Deathball Count: {bulletCount("DeathBall")}");
            ImGui.Text($"Cannon Rotation {cannon.transform.eulerAngles.z}");
        }

        if (ImGui.CollapsingHeader("Logic")) {
            ImGui.Text($"Timescale Speed: {Time.timeScale.ToString("#0.##%")}%");
            ImGui.Text($"Fixed DeltaTime: {Time.fixedDeltaTime}");
            ImGui.Text($"Tickrate: {Time.fixedDeltaTime * 10000}");
            // todo: have GPU and CPU timing showing somehow
            // ProfilerRecorder gfxTime = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Gfx.PresentFrame");

        }

        ImGui.SetWindowPos(new Vector2(10, 120));
        ImGui.SetWindowSize(new Vector2(300, 400));
        
        // ImGui.Text($"GPU Frame Time: {gfxTime.LastValue}"); // TODO: not func atm, will look into CPU and GPU timings later
        
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