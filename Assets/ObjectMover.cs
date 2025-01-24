using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;

    // Hareket hızını artırmak için bir faktör ekleyin
    public float moveSpeed = 2f; // Hız faktörü

    void Update()
    {
        // Dokunma olayları (touch) ile hareketi kontrol et
        if (isDragging)
        {
            // Dokunma ile nesnenin yeni pozisyonunu al
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0); // İlk dokunuşu al
                Vector3 touchPosition = new Vector3(touch.position.x, touch.position.y, 10f); // Z pozisyonunu ayarlıyoruz (kamera mesafesi)
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition); // Dünya koordinatlarına dönüştür

                // Nesneyi, dokunma pozisyonuna doğru hareket ettir
                transform.position = Vector3.Lerp(transform.position, worldPosition + offset, moveSpeed * Time.deltaTime);
            }
        }
    }

    void OnTouchStart()
    {
        // Dokunma başladığında nesnenin pozisyonunu kaydet
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = new Vector3(touch.position.x, touch.position.y, 10f); // Z pozisyonunu ayarlıyoruz
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);

            offset = transform.position - worldPosition; // Nesnenin ve dokunma pozisyonunun farkını hesapla
            isDragging = true; // Sürükleme başladığını işaretle
        }
    }

    void OnTouchEnd()
    {
        // Dokunma sona erdiğinde sürüklemeyi durdur
        isDragging = false;
    }

    // Unity'nin UI sistemine uygun olabilmesi için bu fonksiyonu ekleyebilirsiniz
    void OnMouseDown() 
    {
        OnTouchStart();
    }

    void OnMouseUp() 
    {
        OnTouchEnd();
    }
}
