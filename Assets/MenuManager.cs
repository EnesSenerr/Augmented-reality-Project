using UnityEngine;
using UnityEngine.UI;  // UI.Text için
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
     public TextMeshProUGUI score2Text;
    

    void Start()
    {
        // PlayerPrefs'ten puanı alıp, UI'da göster
        int playerScore = PlayerPrefs.GetInt("PlayerScore", 0); // Eğer puan yoksa varsayılan olarak 0 al
        scoreText.text = "Puanınız: " + playerScore.ToString();  // Puanı metin elemanına yaz
        int playerScore2 = PlayerPrefs.GetInt("Level2Score", 0); // Puan yoksa varsayılan olarak 0
        score2Text.text = "Zaman Puanınız: " + playerScore2.ToString();
    }
}
