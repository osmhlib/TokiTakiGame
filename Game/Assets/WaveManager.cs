using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject mobPrefab;
    public int waveSize = 5;
    public float spawnRadius = 10f;

    public List<MobBehavior> currentWave = new List<MobBehavior>();

    public void Start()
    {
        SpawnWave(); // Початкова хвиля
    }

    public void SpawnWave()
    {
        for (int i = 0; i < waveSize; i++)
        {
            Vector3 spawnPosition = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;
            GameObject mob = Instantiate(mobPrefab, spawnPosition, Quaternion.identity);
            currentWave.Add(mob.GetComponent<MobBehavior>());
        }
    }

    public void EvaluateWave()
    {
        // Сортуємо мобів за завданою шкодою
        currentWave.Sort((a, b) => b.damageDealt.CompareTo(a.damageDealt));
        MobBehavior bestMob = currentWave[0];
        GenerateNextWave(bestMob);
    }

    void GenerateNextWave(MobBehavior parent)
    {
        currentWave.Clear();

        for (int i = 0; i < waveSize; i++)
        {
            Vector3 spawnPosition = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;
            GameObject mob = Instantiate(mobPrefab, spawnPosition, Quaternion.identity);
            MobBehavior mobBehavior = mob.GetComponent<MobBehavior>();

            // Кросовер і мутація
            mobBehavior.speed = Mathf.Clamp(parent.speed + Random.Range(-0.2f, 0.2f), 0.5f, 5f);
            mobBehavior.attackPower = Mathf.Clamp(parent.attackPower + Random.Range(-1f, 1f), 1f, 20f);
            mobBehavior.health = Mathf.Clamp(parent.health + Random.Range(-10f, 10f), 50f, 200f);

            currentWave.Add(mobBehavior);
        }
    }
}


