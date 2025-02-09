using UnityEngine;

public class RomanNumeral2 : MonoBehaviour
{
    public int numeralValue; 
    private Vector3 originalPosition; 
    private Quaternion originalRotation; 

    private Vector3 offset;
    private bool isDragging = false;
    public float moveSpeed = 15f; // Hareket hızı
    
    void Start()
    {
        originalPosition = transform.position; // Başlangıç pozisyonunu kaydet
        originalRotation = transform.rotation; // Başlangıç rotasyonunu kaydet
    }

    public void ResetToOriginalPosition()
    {   
        // Yanlış eşleşmede eski pozisyona ve rotasyona dön
        transform.position = originalPosition; 
        transform.rotation = originalRotation; 
    }

    void Update()
    {
        if (isDragging)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    Vector3 touchPosition = new Vector3(touch.position.x, touch.position.y, 10f);
                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);
                    transform.position = Vector3.Lerp(transform.position, worldPosition + offset, moveSpeed * Time.deltaTime);
                }
            }
            else if (Input.GetMouseButton(0))
            {
                Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
                transform.position = Vector3.Lerp(transform.position, worldPosition + offset, moveSpeed * Time.deltaTime);
            }
        }
    }

    void OnMouseDown()
    {
        StartDragging(Input.mousePosition);
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void StartDragging(Vector2 inputPosition)
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(inputPosition.x, inputPosition.y, 10f));
        offset = transform.position - worldPosition;
        isDragging = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DropZone"))
        {
            isDragging = false; // Bırakıldığı yerde sabitle
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("DropZone"))
        {
            ResetToOriginalPosition(); // Yanlış eşleşmede geri döndür
        }
    }

    void OnTouchStart()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                StartDragging(touch.position);
            }
        }
    }
}
