using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public List<GameObject> currentWave = new List<GameObject>();
    public int waveNumber = 1;
    public GameObject mobPrefab;
    public Transform spawnPoint;

    private MobBehavior bestMob;

    public void EvaluateWave()
    {
        Debug.Log("ќц≥нка хвил≥ " + waveNumber);

        foreach (var mob in currentWave)
        {
            var mobBehavior = mob.GetComponent<MobBehavior>();
            if (mobBehavior != null && (bestMob == null || mobBehavior.attackPower > bestMob.attackPower))
            {
                bestMob = mobBehavior;
            }
        }

        waveNumber++;
        GenerateNextWave();
    }

    private void GenerateNextWave()
    {
        currentWave.Clear();

        for (int i = 0; i < waveNumber * 5; i++)
        {
            var mob = Instantiate(mobPrefab, spawnPoint.position, Quaternion.identity);
            var mobBehavior = mob.GetComponent<MobBehavior>();

            float health = bestMob != null ? bestMob.health + 10 : 100f;
            mobBehavior.Initialize(health, Mathf.Min(5f + waveNumber * 0.5f, 10f), Mathf.Min(10f + waveNumber * 2f, 50f), "Aggressive", this);

            currentWave.Add(mob);
        }
    }
}
