using UnityEngine;
using TMPro;

public class DropZone : MonoBehaviour
{
    public TextMeshProUGUI correctNumberText;
    public TextMeshProUGUI scoreText;
    public LevelManager levelManager;

    private int score = 0;
    private int correctRomanNumber;

    void Start()
    {
        scoreText.text = "Puan: " + score;
    }

    public void ResetForNewLevel()
    {
        scoreText.text = "Puan: " + score;
        SelectNewCorrectNumber();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RomanNumeral"))
        {
            RomanNumeral romanNumeral = other.GetComponent<RomanNumeral>();
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
            RomanNumeral numeral = remainingNumerals[Random.Range(0, remainingNumerals.Length)].GetComponent<RomanNumeral>();
            correctRomanNumber = numeral.numeralValue;
            correctNumberText.text = correctRomanNumber.ToString();
        }
        else
        {
            correctNumberText.text = "Tamamlandı!";
        }
    }
}
