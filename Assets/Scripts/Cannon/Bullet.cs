using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15f;
    public Rigidbody2D rb;
    
    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    void FixedUpdate() {
        // detect if bullet is touching edge of camera
        if (GameObject.Find("Bullet(Clone)").transform.position.x > 0 ||
            GameObject.Find("Bullet(Clone)").transform.position.x > Screen.width ||
            GameObject.Find("Bullet(Clone)").transform.position.y > 0 ||
            GameObject.Find("Bullet(Clone)").transform.position.y > Screen.height) {
            Destroy(GameObject.Find("Bullet(Clone)"));
        }
    }

}
