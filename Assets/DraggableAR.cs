using UnityEngine;
using Vuforia;

public class DraggableAR : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    private Camera arCamera;

    void Start()
    {
        arCamera = Camera.main; // Vuforia'nın ana kamerası
    }

    void OnTouchBegan(UnityEngine.EventSystems.PointerEventData eventData)
    {
        screenPoint = arCamera.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - arCamera.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, screenPoint.z));
    }

    void OnTouchMoved(UnityEngine.EventSystems.PointerEventData eventData)
    {
        Vector3 currentScreenPoint = new Vector3(eventData.position.x, eventData.position.y, screenPoint.z);
        Vector3 currentWorldPoint = arCamera.ScreenToWorldPoint(currentScreenPoint) + offset;
        transform.position = currentWorldPoint;
    }
}
