using UnityEngine;

public class BGLooper : MonoBehaviour
{
    public GameManager gameManager;
    public float backgroundWidth = 3.2f; // Lebar background, sesuaikan dengan ukuran sprite
    private Transform background1, background2; // Dua background yang akan saling bergantian

    private void Start()
    {
        // Temukan dua background di hierarki sebagai bagian dari sistem loop
        background1 = transform.GetChild(0); // Background pertama
        background2 = transform.GetChild(1); // Background kedua

        // Atur posisi awal background
        background1.position = Vector3.zero;
        background2.position = new Vector3(backgroundWidth, 0, 0);
    }

    private void Update()
    {
        if (gameManager.gamePhase == GamePhase.Gameplay)
        {
            // Geser kedua background ke kiri
            background1.position += Vector3.left * Time.deltaTime;
            background2.position += Vector3.left * Time.deltaTime;

            // Pindahkan background pertama ke depan jika keluar dari layar
            if (background1.position.x <= -backgroundWidth)
            {
                background1.position = new Vector3(background2.position.x + backgroundWidth, background1.position.y, background1.position.z);
                SwapReferencesBackground();
            }

            // Pindahkan background kedua ke depan jika keluar dari layar
            if (background2.position.x <= -backgroundWidth)
            {
                background2.position = new Vector3(background1.position.x + backgroundWidth, background2.position.y, background2.position.z);
                SwapReferencesBackground();
            }
        }
    }

    private void SwapReferencesBackground()
    {
        // Tukar referensi background agar selalu tahu mana yang ada di depan
        Transform temp = background1;
        background1 = background2;
        background2 = temp;
    }
}
