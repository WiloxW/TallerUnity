using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 45.0f;
    private Rigidbody rb;
    public float RotationSpeed = 1.0f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Configuración importante del Rigidbody
        if (rb != null)
        {
            rb.freezeRotation = true; // Evita rotaciones no deseadas
        }
        
        // Asegurar que el player tenga Collider
        if (GetComponent<Collider>() == null)
        {
            gameObject.AddComponent<CapsuleCollider>();
        }
    }
    
    void Update()
    {  
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(horizontal, 0, vertical) * Speed;
        
        // Mover usando Rigidbody (recomendado para colisiones)
        if (rb != null)
        {
            rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);
        }
        else
        {
            // Fallback: movimiento directo (puede atravesar colliders)
            transform.Translate(movement * Time.deltaTime);
        }
        float rotationY = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, rotationY * Time.deltaTime * RotationSpeed, 0));
    }
}
