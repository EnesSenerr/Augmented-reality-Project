using UnityEngine;

public class DropZone : MonoBehaviour
{
    // Küp ile çakıştığında
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RomanNumeral"))  // Roma rakamı olduğu sürece
        {
            Debug.Log("Roma rakamı doğru alanda!");
            // Burada Roma rakamını doğru kutuya bıraktığınızda yapılacak işlemi ekleyebilirsiniz.
        }
    }
}
