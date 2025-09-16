using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class WaterController : MonoBehaviour
{
    public float swimSpeed = 3f;
    public float diveSpeed = 2f;
    public float floatSmooth = 2f;

    [Header("Visual Reference")]
    public Transform playerVisual;   // karakterin model/mesh objesi

    private Rigidbody rb;
    private Collider col;

    private bool isInWater = false;
    private float surfaceY = 0f;
    private float halfHeight = 1f;

    private float smoothVel = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        halfHeight = col.bounds.extents.y;
    }

    void Update()
    {
        if (!isInWater) return;

        float targetY = rb.position.y;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            // Dalma
            targetY = rb.position.y - diveSpeed * Time.deltaTime;

            // Visual'ı X ekseninde 180 dereceye doğru döndür
            if (playerVisual != null)
            {
                Quaternion targetRot = Quaternion.Euler(130f, 0f, 0f);
                playerVisual.localRotation = Quaternion.Slerp(
                    playerVisual.localRotation, targetRot, Time.deltaTime * 3f
                );
            }
        }
        else
        {
            // Yüzeye çıkma
            targetY = surfaceY - halfHeight;

            // Visual'ı tekrar 0 dereceye döndür
            if (playerVisual != null)
            {
                Quaternion targetRot = Quaternion.Euler(0f, 0f, 0f);
                playerVisual.localRotation = Quaternion.Slerp(
                    playerVisual.localRotation, targetRot, Time.deltaTime * 3f
                );
            }
        }

        // Dikey hareket smoothing
        float newY = Mathf.SmoothDamp(rb.position.y, targetY, ref smoothVel, 1f / floatSmooth);

        // Yatay hareket
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 move = transform.TransformDirection(new Vector3(h, 0, v)) * swimSpeed;

        rb.linearVelocity = new Vector3(move.x, 0f, move.z);
        rb.position = new Vector3(rb.position.x, newY, rb.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            isInWater = true;
            Transform surface = other.transform.Find("WaterSurface");
            if (surface != null)
                surfaceY = surface.position.y;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            isInWater = false;
        }
    }
}
