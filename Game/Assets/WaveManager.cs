using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public List<GameObject> currentWave = new List<GameObject>(); // ������ ��� ������� ����
    public int waveNumber = 1;

    // ����� ��� ������ ���� ���� �� ����������
    public void EvaluateWave()
    {
        Debug.Log("������ ���� " + waveNumber);
        // ������� ����� ��� ������ �� ��������� ���� ����
        waveNumber++;
        GenerateNextWave();
    }

    // ����� ��� ��������� �������� ����
    private void GenerateNextWave()
    {
        // ������� ��� ��� ��������� ����� ����, ���������:
        Debug.Log("��������� ���� ����: " + waveNumber);
        // ������� ��� ��'���� ���� � ������� �� � currentWave
    }
}