using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            MobBehavior mob = other.GetComponent<MobBehavior>();
            if (mob != null)
            {
                mob.TakeDamage(damage);
                Destroy(gameObject);
            }
        }

        if (other.CompareTag("Player"))
        {
            HealthManager playerHealth = other.GetComponent<HealthManager>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                Destroy(gameObject);
                Debug.Log("Player hit by enemy bullet!");
            }
        }
    }
}
