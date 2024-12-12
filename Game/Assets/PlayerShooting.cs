using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Префаб кулі
    public Transform firePoint; // Точка вогню
    public float bulletSpeed = 20f; // Швидкість кулі
    public float fireRate = 0.5f; // Частота стрільби

    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate; // Встановіть час наступного пострілу
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.velocity = firePoint.forward * bulletSpeed; // Напрямок кулі
            Destroy(bullet, 5f); // Знищте кулю через 5 секунд, якщо не влучила
        }

        Debug.Log("Player shoots!");
    }
}
