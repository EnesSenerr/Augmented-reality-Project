using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] romanPrefabs; // Roma rakamları prefableri
    public int numberOfRomansToSpawn = 5; // Spawn edilecek rakam sayısı
    public Vector3 spawnArea = new Vector3(5f, 5f, 5f); // Spawn alanının boyutları

    private void Start()
    {
        SpawnRomans();
    }

    void SpawnRomans()
    {
        if (romanPrefabs.Length == 0)
        {
            Debug.LogError("Roman Prefabs array is empty! Assign some prefabs in the Inspector.");
            return;
        }

        for (int i = 0; i < numberOfRomansToSpawn; i++)
        {
            // Rastgele bir prefab seç
            GameObject roman = romanPrefabs[Random.Range(0, romanPrefabs.Length)];

            // Spawn pozisyonunu belirle
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
                Random.Range(-spawnArea.y / 2, spawnArea.y / 2),
                Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
            );

            // Prefabı oluştur
            Instantiate(roman, randomPosition, Quaternion.identity);
        }
    }
}
