using UnityEngine;

public class BaseLooper : MonoBehaviour
{
    public GameManager gameManager;
    public float baseWidth = 3.2f; // Lebar base, sesuaikan dengan ukuran sprite
    private Transform base1, base2; // Dua base yang akan saling bergantian

    private void Start()
    {
        // Temukan dua base di hierarki sebagai bagian dari sistem loop
        base1 = transform.GetChild(0); // base pertama
        base2 = transform.GetChild(1); // base kedua

        // Atur posisi awal base
        base1.position = new Vector3(0, base1.position.y, base1.position.z);
        base2.position = new Vector3(baseWidth, base1.position.y, base1.position.z); // Sesuaikan dengan posisi base1 di sumbu y
    }

    private void Update()
    {
        if (gameManager.gamePhase == GamePhase.Gameplay)
        {
            // Geser kedua base ke kiri (tetap di posisi y yang sama)
            base1.position += Vector3.left * Time.deltaTime;
            base2.position += Vector3.left * Time.deltaTime;

            // Pindahkan base pertama ke depan jika keluar dari layar
            if (base1.position.x <= -baseWidth)
            {
                base1.position = new Vector3(base2.position.x + baseWidth, base1.position.y, base1.position.z); // Pastikan y tetap sama
                SwapReferencesBase();
            }

            // Pindahkan base kedua ke depan jika keluar dari layar
            if (base2.position.x <= -baseWidth)
            {
                base2.position = new Vector3(base1.position.x + baseWidth, base2.position.y, base2.position.z); // Pastikan y tetap sama
                SwapReferencesBase();
            }
        }
    }

    private void SwapReferencesBase()
    {
        // Tukar referensi base agar selalu tahu mana yang ada di depan
        Transform temp = base1;
        base1 = base2;
        base2 = temp;
    }
}
