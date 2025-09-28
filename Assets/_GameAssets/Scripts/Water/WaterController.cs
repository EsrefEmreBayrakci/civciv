using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class WaterController : MonoBehaviour
{
    public float swimSpeed = 3f;
    public float diveSpeed = 2f;
    public float floatSmooth = 2f;

    [Header("Visual Reference")]
    public Transform playerVisual;

    private Rigidbody rb;
    private Collider col;

    public bool isInWater = false;
    private float surfaceY = 0f;
    private float halfHeight = 1f;

    private float smoothVel = 0f;


    private playerContrroller playerContrroller;
    private stateController stateController;




    void Start()
    {
        playerContrroller = GetComponent<playerContrroller>();
        stateController = GetComponent<stateController>();
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        halfHeight = col.bounds.extents.y;
    }

    [System.Obsolete]
    void Update()
    {
        if (!isInWater) return;
        if (Input.GetKey(KeyCode.F) && isInWater)
        {
            playerContrroller.playerJump(20f);
            stateController.changeState(playerState.jump);
            isInWater = false;
            FindObjectOfType<playerContrroller>().SetSwimming(false);

        }

        float targetY = rb.position.y;

        if (Input.GetKey(KeyCode.LeftShift))
        {


            // Dalma
            targetY = rb.position.y - diveSpeed * Time.deltaTime;
            BreathRadial.Instance.SetUnderwater(true, true);

            if (playerVisual != null)
            {
                Quaternion targetRot = Quaternion.Euler(130f, 0f, 0f);
                playerVisual.localRotation = Quaternion.Slerp(
                    playerVisual.localRotation, targetRot, Time.deltaTime * 1f
                );
            }
        }
        else
        {


            // Yüzeye çıkma
            targetY = surfaceY - halfHeight;

            BreathRadial.Instance.SetUnderwater(false, true);

            if (playerVisual != null)
            {
                Quaternion targetRot = Quaternion.Euler(0f, 0f, 0f);
                playerVisual.localRotation = Quaternion.Slerp(
                    playerVisual.localRotation, targetRot, Time.deltaTime * 3f
                );
            }
        }



        float newY = Mathf.SmoothDamp(rb.position.y, targetY, ref smoothVel, 1f / floatSmooth);


        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 move = transform.TransformDirection(new Vector3(h, 0, v)) * swimSpeed;

        rb.linearVelocity = new Vector3(move.x, 0f, move.z);
        rb.position = new Vector3(rb.position.x, newY, rb.position.z);
    }

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            BreathRadial.Instance.SetUnderwater(false, true);
            isInWater = true;
            FindObjectOfType<playerContrroller>().SetSwimming(true);
            Transform surface = other.transform.Find("WaterSurface");
            if (surface != null)
                surfaceY = surface.position.y;
        }
    }

    [System.Obsolete]
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            FindObjectOfType<playerContrroller>().SetSwimming(false);
            isInWater = false;

            BreathRadial.Instance.SetUnderwater(false, false);
        }
    }
}
