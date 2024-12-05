using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBehavior : MonoBehaviour
{
    public float health = 100f;
    public float attackPower = 10f;
    public float speed = 2f;
    public float damageDealt = 0f;

    private Transform player;
    private IMobBehavior behavior;

    public void Initialize(float health, float speed, float attackPower, string behaviorType)
    {
        this.health = health;
        this.speed = speed;
        this.attackPower = attackPower;
        behavior = BehaviorFactory.Create(behaviorType);
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        behavior?.Act(this, player);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }
}



