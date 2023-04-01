using System;
using UnityEngine;

public class RingGen : MonoBehaviour {
    public int steps;
    public float radius;
    public LineRenderer circleRenderer;
    // Start is called before the first frame update
    void Start() {
        DrawCircle(steps, radius);
    }

    // Update is called once per frame
    void Update() {
        
    }

    void DrawCircle(int steps, float radius) {
        circleRenderer.positionCount = steps+1;

        for (int currentStep = 0; currentStep < steps; currentStep++) {
            float circumvenceProcress = (float)currentStep / steps;

            float currentRadian = circumvenceProcress * 2 * Mathf.PI;

            float xScaled = Mathf.Cos(currentRadian);
            float yScaled = MathF.Sin(currentRadian);

            float x = xScaled * radius;
            float y = yScaled * radius;

            Vector3 currentPosition = new Vector3(x, y, -1);
            
            circleRenderer.SetPosition(currentStep, currentPosition);
        }
        circleRenderer.SetPosition(steps, circleRenderer.GetPosition(1));
    }
    
}
