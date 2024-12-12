using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance; // ������� �� ����

    public WaveManager waveManager;
    public HealthManager playerHealth;

    void Awake()
    {
        // �������������, �� � ���� ���� ��������� GameController
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (playerHealth.GetHealth() <= 0)
        {
            GameOver();
        }

        if (waveManager.currentWave.Count == 0 && waveManager.waveNumber > 0)
        {
            waveManager.EvaluateWave();
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        // ������� ����� ��� ���������� ���, ���������, ���������� ����� ��� ����� ����
    }
}
