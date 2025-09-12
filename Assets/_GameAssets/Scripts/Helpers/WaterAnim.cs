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

        // URP Lit shader için (albedo/base map kaydırma)
        if (waterMat.HasProperty("_BaseMap"))
            waterMat.SetTextureOffset("_BaseMap", offset);

        // Built-in Standard shader için (main texture kaydırma)
        if (waterMat.HasProperty("_MainTex"))
            waterMat.SetTextureOffset("_MainTex", offset);

        // Normal map kaydırma (opsiyonel)
        if (waterMat.HasProperty("_BumpMap"))
            waterMat.SetTextureOffset("_BumpMap", offset);
    }
}
