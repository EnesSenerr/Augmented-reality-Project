using UnityEngine;

public class RomanNumeral : MonoBehaviour
{
    public int numeralValue; // Prefab'ın sayısal değeri (örneğin, 1, 2, 3...)
    private Vector3 originalPosition; // Başlangıç pozisyonu
    private Quaternion originalRotation; // Başlangıç rotasyonu

    private Vector3 offset;
    private bool isDragging = false;
    public float moveSpeed = 15f; // Hareket hızı
    
    void Start(){
         originalPosition = transform.position; // Başlangıç pozisyonunu kaydet
        originalRotation = transform.rotation; // Başlangıç rotasyonunu kaydet
    }
    public void ResetToOriginalPosition()
    {
        transform.position = originalPosition; // Pozisyonu sıfırla
        transform.rotation = originalRotation; // Rotasyonu sıfırla
    }
    void Update()
    {
        if (isDragging)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 touchPosition = new Vector3(touch.position.x, touch.position.y, 10f);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);
                transform.position = Vector3.Lerp(transform.position, worldPosition + offset, moveSpeed * Time.deltaTime);
            }
        }
    }

    void OnTouchStart()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = new Vector3(touch.position.x, touch.position.y, 10f);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);

            offset = transform.position - worldPosition;
            isDragging = true;
        }
    }

    void OnTouchEnd()
    {
        isDragging = false;
    }

    void OnMouseDown()
    {
        OnTouchStart();
    }

    void OnMouseUp()
    {
        OnTouchEnd();
    }
}
