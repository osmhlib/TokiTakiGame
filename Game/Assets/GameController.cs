using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public WaveManager waveManager;
    public HealthManager playerHealth;

    void Update()
    {
        if (playerHealth.GetHealth() <= 0)
        {
            Debug.Log("Game Over");
            // Додайте логіку завершення гри
        }

        if (waveManager.currentWave.Count == 0)
        {
            waveManager.EvaluateWave();
        }
    }
}
