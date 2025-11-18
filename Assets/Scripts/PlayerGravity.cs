using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    public float gravityScale = 2.0f;
    private Rigidbody rb;
    private Vector3 gravity;
                
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Desactivar gravedad automática
        gravity = Physics.gravity * gravityScale;
    }
    
    void FixedUpdate()
    {
        // Aplicar gravedad personalizada
        rb.AddForce(gravity, ForceMode.Acceleration);
    }
}