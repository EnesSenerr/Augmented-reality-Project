using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 offset;
    private Camera arCamera;

    void Start()
    {
        arCamera = Camera.main;
    }

    void OnMouseDown()
    {
        offset = gameObject.transform.position - GetMouseWorldPosition();
    }

    void OnMouseDrag()
    {
        Vector3 newPosition = GetMouseWorldPosition() + offset;
        gameObject.transform.position = newPosition;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = arCamera.nearClipPlane + 0.5f; // Kamera uzaklığı
        return arCamera.ScreenToWorldPoint(mousePosition);
    }

    void OnMouseUp()
    {
        // Kutunun içine bırakıldığında doğruluğu kontrol edebilirsiniz
    }
}
