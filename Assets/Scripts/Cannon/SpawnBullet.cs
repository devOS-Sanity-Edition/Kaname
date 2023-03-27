using System.Collections;
using System.Collections.Generic;
using NiceIO.Sysroot;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private GameObject bulletObject;

    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
        
        // detect if bullet is touching edge of camera
        // if (GameObject.Find("Bullet(Clone)").transform.position.x > 0 ||
        //     GameObject.Find("Bullet(Clone)").transform.position.x > Screen.width ||
        //     GameObject.Find("Bullet(Clone)").transform.position.y > 0 ||
        //     GameObject.Find("Bullet(Clone)").transform.position.y > Screen.height) {
        //     Delete();
        // }
        // so the console is being spammed with `NullReferenceException` errors before a bullet even spawns, time to kill this for now!
    }

    void Shoot() {
       bulletObject = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void Delete() {
        GameObject.Destroy(bulletObject);
    }
    
}
