using System.Collections;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    [Header("Referanslar")]
    [SerializeField] Transform playerTransform;
    [SerializeField] Transform orientationTransform;
    [SerializeField] Transform playerVisualTransform;

    [Header("Kamera Ayarları")]
    [SerializeField] float rotationSpeed;



    void Update()
    {
        if (GameManager.Instance.currentGameState != gameState.play && GameManager.Instance.currentGameState != gameState.resume)
        {
            return;
        }

        //Kamera'nın bakış yönünün ayarlanması
        Vector3 viewDirection = playerTransform.position - new Vector3(transform.position.x, playerTransform.position.y, transform.position.z);

        orientationTransform.forward = viewDirection.normalized;

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");


        Vector3 inputDirection = orientationTransform.forward * verticalInput + orientationTransform.right * horizontalInput;

        if (inputDirection != Vector3.zero)
        {
            playerVisualTransform.forward = Vector3.Slerp(playerVisualTransform.forward, inputDirection.normalized, Time.deltaTime * rotationSpeed);
        }



    }
}
