using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Vector3 offset;
    private Camera arCamera;
    private bool isDragging = false;

    // Nesneyle etkileşime girildiğinde
    void OnMouseDown()
    {
        arCamera = Camera.main; // Kamera referansı al
        offset = transform.position - arCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, arCamera.WorldToScreenPoint(transform.position).z));
        isDragging = true;
    }

    // Nesne sürüklendiğinde
    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, arCamera.WorldToScreenPoint(transform.position).z);
            Vector3 currentWorldPoint = arCamera.ScreenToWorldPoint(currentScreenPoint) + offset;
            transform.position = currentWorldPoint; // Nesneyi yeni pozisyona taşı
        }
    }

    // Dokunma sona erdiğinde sürüklemeyi durdur
    void OnMouseUp()
    {
        isDragging = false;
    }
}
