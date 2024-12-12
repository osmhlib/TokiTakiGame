using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBehavior : MonoBehaviour
{
    public float health = 100f;
    public float attackPower = 10f;
    public float speed = 2f;
    public GameObject enemyBulletPrefab; // ������ �������
    public float fireRate = 1f; // ������� �������
    private float nextFireTime = 0f; // ��� ���������� �������

    private Transform player;
    private IMobBehavior behavior;
    private WaveManager waveManager;

    public void Initialize(float health, float speed, float attackPower, string behaviorType, WaveManager waveManager)
    {
        this.health = health;
        this.speed = speed;
        this.attackPower = attackPower;
        this.waveManager = waveManager;
        behavior = BehaviorFactory.Create(behaviorType);
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        behavior?.Act(this, player);
        TryShoot(); // ��������� �������
    }

    private void TryShoot()
    {
        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate; // ��������� ��� ���������� �������
            AttackPlayer(player); // ����� ������
        }
    }

    public void AttackPlayer(Transform player)
    {
        GameObject projectile = Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity);

        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        if (rb != null)
        {
            Vector3 direction = (player.position - transform.position).normalized; // �������� �� ������
            rb.velocity = direction * 10f; // ������� �������� ������� (�������� ��� ������� ����)
            Destroy(projectile, 5f); // ������ ������ ����� 5 ������, ���� �� ������
        }

        Debug.Log("Mob attacks player!");
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            waveManager.currentWave.Remove(gameObject);
            Destroy(gameObject);
            Debug.Log("Mob defeated!");
        }
    }
}
