using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour {
    public Transform firePoint;
    public GameObject bulletPrefab;
    private List<Texture> clones = new List<Texture>();

    void Update() {
        if (Input.GetButtonDown("Fire1")) { Shoot(); }
    }

    void Shoot() {
        if (bulletCount() < 1) { Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); }
    }


    int bulletCount() {
        int count = 0;
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject bullet in bullets) { count++; }

        return count;
    }
}