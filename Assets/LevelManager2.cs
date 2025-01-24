using UnityEngine;
using UnityEngine.SceneManagement; // SceneManager için

public class LevelManager2 : MonoBehaviour
{
    public RomanNumeralSpawner2 spawner; // RomanNumeralSpawner referansı
    public DropZone2 dropZone; // DropZone referansı
    public float levelTime = 60f; // Başlangıçta oyun süresi (saniye olarak)
    
    private int currentLevel = 1; // Başlangıç seviyesi
    private float currentTime; // Geçerli zaman
    private int playerScore2 = 0; // Oyuncunun skoru

    void Start()
    {
        currentTime = levelTime; // Başlangıçta zaman limitini ayarla
        StartLevel(currentLevel); // İlk seviyeyi başlat
    }

    void Update()
    {
        // Zamanlayıcıyı güncelle
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            // Zaman bittiğinde oyun bitir
            EndGame();
        }
    }

    public void StartLevel(int level)
    {
        if (spawner == null || dropZone == null)
        {
            Debug.LogError("Spawner veya DropZone, Editör'de atanmamış!");
            return;
        }

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
        playerScore2 += 10; // Her seviyeyi tamamladıkça puan ekle
        currentLevel++;

        // Bölüm geçtikçe 10 saniye ekleyelim
        currentTime += 10f; // Her bölümde 10 saniye eklenir

        if (currentLevel > 3)
        {
            Debug.Log("Tüm seviyeler tamamlandı!");
            // Oyun bittiğinde yapılacak işlemler
            EndGame();
        }
        else
        {
            StartLevel(currentLevel);
        }
    }

    void EndGame()
    {
        // Oyun bittiğinde, skoru PlayerPrefs'e kaydediyoruz
        PlayerPrefs.SetInt("Level2Score", playerScore2); // Farklı bir anahtar ile kaydediyoruz
        
        // Zaman bittiğinde veya tüm seviyeler tamamlandığında sahneye geçiş yap
        SceneManager.LoadScene("Menu"); // "Menu" sahnesine geçiş
    }
}
