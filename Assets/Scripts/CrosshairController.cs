using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    public Texture2D crosshairTexture;
    private Vector2 crosshairHotspot;

    void Start()
    {
        // Set the crosshair hotspot to the center of the texture
        crosshairHotspot = new Vector2(crosshairTexture.width / 2, crosshairTexture.height / 2);

        // Set the custom crosshair
        Cursor.SetCursor(crosshairTexture, crosshairHotspot, CursorMode.Auto);

        // Hide the system cursor
        Cursor.visible = true;
    }

    void Update()
    {
        // Optional: Add crosshair logic if needed (e.g., animations or changing crosshair texture)
    }
}
