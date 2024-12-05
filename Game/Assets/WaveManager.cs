using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public List<GameObject> currentWave = new List<GameObject>(); // Список для поточної хвилі
    public int waveNumber = 1;

    // Метод для оцінки хвилі після її завершення
    public void EvaluateWave()
    {
        Debug.Log("Оцінка хвилі " + waveNumber);
        // Додайте логіку для аналізу та генерації нової хвилі
        waveNumber++;
        GenerateNextWave();
    }

    // Метод для генерації наступної хвилі
    private void GenerateNextWave()
    {
        // Додайте код для створення нових мобів, наприклад:
        Debug.Log("Генерація нової хвилі: " + waveNumber);
        // Створіть нові об'єкти мобів і додайте їх у currentWave
    }
}