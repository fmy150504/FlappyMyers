using UnityEngine;

public class LetterBox : MonoBehaviour
{
    public float targetAspect = 9f / 16f; // Rasio target (9:16)
    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();

        float screenAspect = (float)Screen.width / Screen.height;
        float scale = targetAspect / screenAspect;

        if (scale < 1.0f)
        {
            // Tambahkan letterbox (hitam di atas dan bawah)
            cam.orthographicSize /= scale;
        }
    }
}
