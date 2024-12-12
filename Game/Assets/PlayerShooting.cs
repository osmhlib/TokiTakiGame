using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // ������ ���
    public Transform firePoint; // ����� �����
    public float bulletSpeed = 20f; // �������� ���
    public float fireRate = 0.5f; // ������� �������

    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate; // ��������� ��� ���������� �������
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.velocity = firePoint.forward * bulletSpeed; // �������� ���
            Destroy(bullet, 5f); // ������ ���� ����� 5 ������, ���� �� �������
        }

        Debug.Log("Player shoots!");
    }
}
