using UnityEngine;

public class WaterAnim : MonoBehaviour
{
    public Material waterMat;
    public float speedX = 0.02f;
    public float speedY = 0.01f;

    private Vector2 offset;

    void Update()
    {
        offset.x += speedX * Time.deltaTime;
        offset.y += speedY * Time.deltaTime;


        if (waterMat.HasProperty("_BaseMap"))
            waterMat.SetTextureOffset("_BaseMap", offset);


        if (waterMat.HasProperty("_MainTex"))
            waterMat.SetTextureOffset("_MainTex", offset);


        if (waterMat.HasProperty("_BumpMap"))
            waterMat.SetTextureOffset("_BumpMap", offset);
    }
}
