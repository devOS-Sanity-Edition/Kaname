using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;
using System = FMOD.System;

public class DBOnRing : MonoBehaviour {
    public GameObject DeathballPrefab;
    public int DeathBallAmount = 3;
    private int tempBallPosition;
    private bool isProblematic = true;
    private int circleSteps;

    // Start is called before the first frame update
    void Start() {
        circleSteps = GameObject.Find("RingGen").GetComponent<RingGen>().steps;
        Debug.Log("circleSteps: " + circleSteps);
        for (int i = 0; i < DeathBallAmount; i++) {
            while (isProblematic) {
                tempBallPosition = Random.Range(0, circleSteps);
                Vector3 ballPos = GameObject.Find("RingGen").GetComponent<RingGen>().circleRenderer.GetPosition(tempBallPosition);

                Instantiate(DeathballPrefab, new Vector3(ballPos.x, ballPos.y, ballPos.z), Quaternion.identity);
                
                isProblematic = false;
            }
            isProblematic = true;
        }
    }

    // Update is called once per frame
    void Update() {
        
    }
}
