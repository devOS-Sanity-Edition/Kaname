using ImGuiNET;
using System;
using UnityEngine;

public class DebugMenu : MonoBehaviour {
    bool m_WindowEnabled = false;
    public GameObject cannon;
    bool debugBuild;
    bool displayDebug;
    bool editorBuild;
    string vSyncResult;
    string antiAliasingResult;

    void Start() {
#if UNITY_STANDALONE
        editorBuild = false;
        debugBuild = false;
#endif
#if UNITY_EDITOR
        editorBuild = true;
        debugBuild = true;
#endif
#if DEVELOPMENT_BUILD // IDES ARE GOING TO SAY THIS IS UNREACHABLE CODE! FALSE! THIS ACTUALLY DOES WORK IN DEVELOPMENT BUILDS BUT OF COURSE
                                // IT DOESNT KNOW THAT! AAAAAAAAAAAAAAAAAAA
                editorBuild = false;
                debugBuild = true;
#endif

        if (editorBuild | debugBuild) { displayDebug = true; }
    }

    void Update() {
        switch (QualitySettings.vSyncCount) {
            case 0:
                vSyncResult = "0 [VSYNC IS OFF]";
                break;
            case >= 1:
                vSyncResult = "1-4 [VSYNC IS ON]";
                break;
        }

        switch (QualitySettings.antiAliasing) {
            case 0:
                antiAliasingResult = "0 [MSAA IS OFF]";
                break;
            case 2:
                antiAliasingResult = "2 [MSAA 2x]";
                break;
            case 4:
                antiAliasingResult = "4 [MSAA 4x]";
                break;
            case 8:
                antiAliasingResult = "8 [MSAA 8x]";
                break;
            default:
                antiAliasingResult = "What weird MSAA value was put that Unity doesn't support???";
                break;
        }

        if (Input.GetKeyDown("d")) { displayDebug = !displayDebug; }
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

        ImGui.Text($"FPS: {(int)ImGui.GetIO().Framerate}");
        ImGui.Text($"Frametime: {(float)1000.0f / ImGui.GetIO().Framerate} ms/frame");
        ImGui.Text($"VSync: {vSyncResult}");
        ImGui.Text($"MSAA: {antiAliasingResult}");
        ImGui.Text($"Screen Size: {Screen.width} x {Screen.height}");

        if (ImGui.CollapsingHeader("Build")) {
            ImGui.Text($"Editor Mode: {editorBuild.ToString()}");
            ImGui.Text($"Debug Build: {debugBuild.ToString()}");
        }

        if (ImGui.CollapsingHeader("Game")) {
            ImGui.Text($"Bullet Count: {bulletCount("Bullet")}");
            ImGui.Text($"Deathball Count: {bulletCount("DeathBall")}");
            ImGui.Text($"Cannon Rotation {cannon.transform.eulerAngles.z}");
            if (ImGui.CollapsingHeader("Scoring")) {
                ImGui.Text($"Death Score: {GameObject.Find("ScoreManager").GetComponent<ScoreManager>().deaths}");
                ImGui.Text($"Current Level: {GameObject.Find("ScoreManager").GetComponent<ScoreManager>().level}");
                ImGui.Text($"Record Score: {GameObject.Find("ScoreManager").GetComponent<ScoreManager>().record}");
                ImGui.Separator();
                ImGui.InputInt("Death", ref GameObject.Find("ScoreManager").GetComponent<ScoreManager>().deaths);
                ImGui.InputInt("Level", ref GameObject.Find("ScoreManager").GetComponent<ScoreManager>().level);
                ImGui.InputInt("Record", ref GameObject.Find("ScoreManager").GetComponent<ScoreManager>().record);
            }
        }

        if (ImGui.CollapsingHeader("Logic")) {
            ImGui.Text($"Timescale Speed: {Time.timeScale.ToString("#0.##%")}%");
            ImGui.Text($"Fixed DeltaTime: {Time.fixedDeltaTime}");
            ImGui.Text($"Tickrate: {Time.fixedDeltaTime * 10000}");
        }

        ImGui.SetWindowPos(new Vector2(10, 120));
        ImGui.SetWindowSize(new Vector2(300, 500));
    }

    void OnLayout() {
        if (displayDebug) { ShowDebugView(); }
    }

    int bulletCount(string choice) {
        int count = 0;
        GameObject[] bullets = GameObject.FindGameObjectsWithTag(choice);
        foreach (GameObject bullet in bullets) { count++; }

        return count;
    }
}