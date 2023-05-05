using ImGuiNET;
using System;
using UnityEngine;
using ColorUtility = UnityEngine.ColorUtility;

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
                ImGuiWindowFlags.None))
            return;

        ImGui.Text($"NOTE: ACTUAL GAME COLORS WILL NOT CHANGE \nDYNAMICALLY, ONLY ON LOAD/RELOAD \nFOR NOW!");
        ImGui.Text($"THE ONLY DYNAMIC COLOR CHANGING IS IN \nTHIS DEBUGVIEW FOR NOW!!!");
        ImGui.Text($"FPS: {(int)ImGui.GetIO().Framerate}");
        ImGui.Text($"Frametime: {(float)1000.0f / ImGui.GetIO().Framerate} ms/frame");
        ImGui.Text($"VSync: {vSyncResult}");
        ImGui.Text($"MSAA: {antiAliasingResult}");
        ImGui.BeginGroup();
        if (ImGui.Button("0x")) { QualitySettings.antiAliasing = 0; }

        ImGui.SameLine();
        if (ImGui.Button("2x")) { QualitySettings.antiAliasing = 2; }

        ImGui.SameLine();
        if (ImGui.Button("4x")) { QualitySettings.antiAliasing = 4; }

        ImGui.SameLine();
        if (ImGui.Button("8x")) { QualitySettings.antiAliasing = 8; }

        ImGui.EndGroup();
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
            ImGui.Text($"Fixed DeltaTime: {Time.fixedDeltaTime} seconds \n[{Time.fixedDeltaTime * 1000} ms/t]");
            // thank you bryce for helping me figure out the math my brain hurts
            // 16900 comes from 130 / Time.fixedDeltaTime [so reversing the math to make it 130t/s]
            // ow my brain ow m y brain
            ImGui.Text($"Tickrate: {Time.fixedDeltaTime * 16900}");
        }

        // Get the theme
        GameColorManager.Theme theme = GameObject.Find("GameColorManager").GetComponent<GameColorManager>().InternalGameTheme;

        // Theme.GameColors
        if (ImGui.CollapsingHeader("Game Colors")) {
            GameColorManager.GameColors color = theme.GameColors;
            if (ColorUtility.TryParseHtmlString($"#{color.Background}", out Color background)) {
                ImGui.TextColored(new Vector4(background.r, background.g, background.b, background.a), $"Background: #{color.Background}");
            }

            if (ColorUtility.TryParseHtmlString($"#{color.BackgroundCircle}", out Color backgroundCircle)) {
                ImGui.TextColored(new Vector4(backgroundCircle.r, backgroundCircle.g, backgroundCircle.b, backgroundCircle.a),
                    $"BackgroundCircle: #{color.BackgroundCircle}");
            }

            if (ColorUtility.TryParseHtmlString($"#{color.Bullet}", out Color bullet)) {
                ImGui.TextColored(new Vector4(bullet.r, bullet.g, bullet.b, bullet.a), $"Bullet: #{color.Bullet}");
            }

            if (ColorUtility.TryParseHtmlString($"#{color.Cannon}", out Color cannonColor)) {
                ImGui.TextColored(new Vector4(cannonColor.r, cannonColor.g, cannonColor.b, cannonColor.a), $"Cannon: #{color.Cannon}");
            }

            if (ColorUtility.TryParseHtmlString($"#{color.DeathFlash}", out Color deathFlash)) {
                ImGui.TextColored(new Vector4(deathFlash.r, deathFlash.g, deathFlash.b, deathFlash.a), $"DeathFlash: #{color.DeathFlash}");
            }

            if (ColorUtility.TryParseHtmlString($"#{color.ObstacleLayer1}", out Color obstacleLayer1)) {
                ImGui.TextColored(new Vector4(obstacleLayer1.r, obstacleLayer1.g, obstacleLayer1.b, obstacleLayer1.a),
                    $"ObstacleLayer1: #{color.ObstacleLayer1}");
            }

            if (ColorUtility.TryParseHtmlString($"#{color.ObstacleLayer2}", out Color obstacleLayer2)) {
                ImGui.TextColored(new Vector4(obstacleLayer2.r, obstacleLayer2.g, obstacleLayer2.b, obstacleLayer2.a),
                    $"ObstacleLayer2: #{color.ObstacleLayer2}");
            }

            if (ColorUtility.TryParseHtmlString($"#{color.ObstacleLayer3}", out Color obstacleLayer3)) {
                ImGui.TextColored(new Vector4(obstacleLayer3.r, obstacleLayer3.g, obstacleLayer3.b, obstacleLayer3.a),
                    $"ObstacleLayer3: #{color.ObstacleLayer3}");
            }

            if (ColorUtility.TryParseHtmlString($"#{color.ObstacleLayer4}", out Color obstacleLayer4)) {
                ImGui.TextColored(new Vector4(obstacleLayer4.r, obstacleLayer4.g, obstacleLayer4.b, obstacleLayer4.a),
                    $"ObstacleLayer4: #{color.ObstacleLayer4}");
            }

        }

        if (ImGui.CollapsingHeader("UI Colors")) {
            GameColorManager.UIColors ui = theme.UIColors;
            if (ColorUtility.TryParseHtmlString($"#{ui.Background}", out Color background)) {
                ImGui.TextColored(new Vector4(background.r, background.g, background.b, background.a), $"Background: #{ui.Background}");
            }

            if (ColorUtility.TryParseHtmlString($"#{ui.Label}", out Color label)) {
                ImGui.TextColored(new Vector4(label.r, label.g, label.b, label.a), $"Label: #{ui.Label}");
            }

            if (ColorUtility.TryParseHtmlString($"#{ui.LabelNumeric}", out Color labelNumeric)) {
                ImGui.TextColored(new Vector4(labelNumeric.r, labelNumeric.g, labelNumeric.b, labelNumeric.a), $"LabelNumeric: #{ui.LabelNumeric}");
            }
        }

        // ImGui.SetWindowPos(new Vector2(10, 120));
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