using UnityEngine;
using UnityEngine.SceneManagement; // SceneManager için

public class LevelManager2 : MonoBehaviour
{
    public RomanNumeralSpawner2 spawner; 
    public DropZone2 dropZone; 
    public float levelTime = 60f; 
    
    private int currentLevel = 1; 
    private float currentTime; 

    void Start()
    {
        currentTime = levelTime;
        StartLevel(currentLevel);
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
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
            spawner.ConfigureSpawner(1, 6);
        }
        else if (level == 2)
        {
            spawner.ConfigureSpawner(6, 11);
        }
        else if (level == 3)
        {
            spawner.ConfigureSpawner(1, 11);
        }

        spawner.SpawnAllRomanNumerals();
        dropZone.ResetForNewLevel();
    }

    public void CompleteLevel()
    {
        currentLevel++;
        currentTime += 10f; 

        if (currentLevel > 3)
        {
            Debug.Log("Tüm seviyeler tamamlandı!");
            EndGame();
        }
        else
        {
            StartLevel(currentLevel);
        }
    }

    void EndGame()
    {
        // Puanı DropZone2 üzerinden al ve kaydet
        PlayerPrefs.SetInt("Level2Score", dropZone.GetScore());
        
        SceneManager.LoadScene("Menu");
    }
}
