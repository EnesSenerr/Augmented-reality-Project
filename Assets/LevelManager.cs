using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public RomanNumeralSpawner spawner; // RomanNumeralSpawner referansı
    public DropZone dropZone; // DropZone referansı

    private int currentLevel = 1; // Başlangıç seviyesi
    private int score = 0; // Puan değişkeni

    void Start()
    {
        StartLevel(currentLevel); // İlk seviyeyi başlat
    }

    public void StartLevel(int level)
    {
        if (level == 1)
        {
            spawner.ConfigureSpawner(1, 6); // 1 ile 5 arasındaki rakamlar
        }
        else if (level == 2)
        {
            spawner.ConfigureSpawner(6, 11); // 6 ile 10 arasındaki rakamlar
        }
        else if (level == 3)
        {
            spawner.ConfigureSpawner(1, 11); // 1 ile 10 arasındaki rakamlar
        }

        spawner.SpawnAllRomanNumerals(); // Rakamları spawn et
        dropZone.ResetForNewLevel(); // DropZone'u sıfırla
    }

    public void CompleteLevel()
    {
        score += 10; // Örnek olarak her seviyeyi tamamladığınızda 10 puan ekliyoruz
        currentLevel++;
        if (currentLevel > 3)
        {
            Debug.Log("Tüm seviyeler tamamlandı!");
            // Oyun bittiğinde, ana menüye puanla birlikte dön
            PlayerPrefs.SetInt("PlayerScore", score);  // Puanı PlayerPrefs'e kaydediyoruz
            SceneManager.LoadScene("Menu");  // "Menu" sahnesi yüklenecek
        }
        else
        {
            StartLevel(currentLevel);
        }
    }
}
