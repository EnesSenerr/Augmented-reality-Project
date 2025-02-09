using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public RomanNumeralSpawner spawner;
    public DropZone dropZone;

    private int currentLevel = 1;

    void Start()
    {
        StartLevel(currentLevel);
    }

    public void StartLevel(int level)
    {
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
        if (currentLevel > 3)
        {
            Debug.Log("Tüm seviyeler tamamlandı!");
            PlayerPrefs.SetInt("PlayerScore", dropZone.GetScore()); // DropZone'daki puanı kaydet
            SceneManager.LoadScene("Menu");
        }
        else
        {
            StartLevel(currentLevel);
        }
    }
}
