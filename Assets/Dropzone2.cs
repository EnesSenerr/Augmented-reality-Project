using UnityEngine;
using TMPro;

public class DropZone2 : MonoBehaviour
{
    public TextMeshProUGUI correctNumberText;
    public TextMeshProUGUI scoreText;
    public LevelManager2 levelManager;
    public TextMeshProUGUI timerText;

    private int score = 0;
    private int correctRomanNumber;
    private float timer = 60f; // Zamanlayıcı süresi

    void Start()
    {
        scoreText.text = "Puan: " + score;
        UpdateTimer();
    }

    public void ResetForNewLevel()
    {
        scoreText.text = "Puan: " + score;
        SelectNewCorrectNumber();
        timer = 60f; // Yeni seviye başlatıldığında zamanlayıcıyı sıfırla
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 0;
            levelManager.CompleteLevel();
        }
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        timerText.text = "Zaman: " + Mathf.FloorToInt(timer).ToString();
    }

    

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RomanNumeral"))
        {
            RomanNumeral2 romanNumeral = other.GetComponent<RomanNumeral2>();
            if (romanNumeral != null)
            {
                if (romanNumeral.numeralValue == correctRomanNumber)
                {
                    score += 10;
                    scoreText.text = "Puan: " + score;
                    Destroy(other.gameObject);
                    Invoke(nameof(SelectNewCorrectNumber), 0.1f);

                    if (GameObject.FindGameObjectsWithTag("RomanNumeral").Length == 1)
                    {
                        levelManager.CompleteLevel();
                    }
                }
                else
                {
                    score -= 5;
                    scoreText.text = "Puan: " + score;
                    romanNumeral.ResetToOriginalPosition();
                }
            }
        }
    }

    private void SelectNewCorrectNumber()
    {
        GameObject[] remainingNumerals = GameObject.FindGameObjectsWithTag("RomanNumeral");
        if (remainingNumerals.Length > 0)
        {
            RomanNumeral2 numeral = remainingNumerals[Random.Range(0, remainingNumerals.Length)].GetComponent<RomanNumeral2>();
            correctRomanNumber = numeral.numeralValue;
            correctNumberText.text = correctRomanNumber.ToString();
        }
        else
        {
            correctNumberText.text = "Tamamlandı!";
        }
    }
    public int GetScore()
{
    return score;
}
}
