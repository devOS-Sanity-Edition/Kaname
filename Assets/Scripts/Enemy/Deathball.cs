using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathball : MonoBehaviour
{
    void OnCollision2D(Collision2D collision) {
        Debug.Log("Collided?");
    }
}
