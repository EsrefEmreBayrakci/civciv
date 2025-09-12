using UnityEngine;

public class WaterController : MonoBehaviour
{
    public float swimForce = 5f;      // Yüzme kuvveti
    public float diveForce = -5f;     // Dalma kuvveti
    private bool isInWater = false;
    private Rigidbody rb;
    
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isInWater)
        {
            // Yüzdürme kuvveti (karakteri batırmamak için yukarı iter)
            rb.AddForce(Vector3.up * swimForce, ForceMode.Acceleration);

            // Dalma tuşu (F'ye basınca aşağı iter)
            if (Input.GetKey(KeyCode.F))
            {
                rb.AddForce(Vector3.up * diveForce, ForceMode.Acceleration);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            isInWater = true;
            rb.linearDamping = 2f;   // Suda hareketi yavaşlat
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            isInWater = false;
            rb.linearDamping = 0f;  // Normal harekete dön
        }
    }
}
