using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI score2Text;

    void Start()
    {
        // Oyunun ilk kez açılıp açılmadığını kontrol et
        if (!PlayerPrefs.HasKey("FirstTime"))
        {
            // İlk defa açılıyorsa, puanları sıfırla
            PlayerPrefs.SetInt("PlayerScore", 0);
            PlayerPrefs.SetInt("Level2Score", 0);

            // "FirstTime" anahtarını kaydederek bir daha sıfırlanmamasını sağla
            PlayerPrefs.SetInt("FirstTime", 1);
            PlayerPrefs.Save(); // Değişiklikleri kaydet
        }

        // Güncel puanları göster
        int playerScore = PlayerPrefs.GetInt("PlayerScore", 0);
        scoreText.text = "Puanınız: " + playerScore.ToString();

        int playerScore2 = PlayerPrefs.GetInt("Level2Score", 0);
        score2Text.text = "Zaman Puanınız: " + playerScore2.ToString();
    }
}
