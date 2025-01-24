using UnityEngine;
using System.Collections.Generic;

public class RomanNumeralSpawner2 : MonoBehaviour
{
    public GameObject[] romanNumerals; // Roma rakamı prefab'ları
    public Vector3 idealPosition = new Vector3(-15f, 0f, 22f); // İdeal spawn pozisyonu
    public float spawnRangeX = 5f; // X ekseninde spawn aralığı
    public float spawnRangeY = 5f; // Y ekseninde spawn aralığı
    public float spawnRangeZ = 5f; // Z ekseninde spawn aralığı

    private List<Vector3> usedPositions = new List<Vector3>(); // Daha önce kullanılan pozisyonlar
    private int minValue = 1; // Minimum değer (default)
    private int maxValue = 5; // Maksimum değer (default)

    public void ConfigureSpawner(int min, int max)
    {
        minValue = min;
        maxValue = max;
    }

    public void SpawnAllRomanNumerals()
    {
        // Var olan rakamları temizle
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        usedPositions.Clear();

        // Sadece belirtilen aralıktaki rakamları spawn et
        foreach (GameObject romanNumeral in romanNumerals)
        {
            RomanNumeral2 numeral = romanNumeral.GetComponent<RomanNumeral2>();
            if (numeral != null && numeral.numeralValue >= minValue && numeral.numeralValue < maxValue)
            {
                Vector3 spawnPosition = GetRandomPosition();
                Instantiate(romanNumeral, spawnPosition, Quaternion.identity, transform);
            }
        }
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 randomPosition;

        do
        {
            randomPosition = new Vector3(
                Random.Range(idealPosition.x - spawnRangeX, idealPosition.x + spawnRangeX),
                Random.Range(idealPosition.y - spawnRangeY, idealPosition.y + spawnRangeY),
                Random.Range(idealPosition.z, idealPosition.z + spawnRangeZ)
            );
        } while (usedPositions.Contains(randomPosition));

        usedPositions.Add(randomPosition);
        return randomPosition;
    }
}
