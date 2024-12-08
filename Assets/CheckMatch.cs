using UnityEngine;

public class CheckMatch : MonoBehaviour
{
    public string correctRomanNumeral; // Doğru Roma rakamı

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains(correctRomanNumeral))
        {
            Debug.Log("Doğru eşleştirme!");
            Destroy(other.gameObject); // Başarıyla eşleştirilen objeyi kaldır
        }
        else
        {
            Debug.Log("Yanlış eşleştirme!");
        }
    }
}
