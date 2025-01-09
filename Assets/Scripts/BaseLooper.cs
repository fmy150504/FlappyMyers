using UnityEngine;
using UnityEngine.UIElements;

public class BaseLooper : MonoBehaviour
{
    public GameManager gameManager;
    public float baseWidth = 3.2f; // Lebar base, sesuaikan dengan ukuran sprite
    private Transform base1, base2, batasAtas1, batasAtas2; // Dua base yang akan saling bergantian

    private void Start()
    {
        // Temukan dua base di hierarki sebagai bagian dari sistem loop
        base1 = transform.GetChild(0); // base pertama
        batasAtas1 = transform.GetChild(1); // base kedua
        base2 = transform.GetChild(2);
        batasAtas2 = transform.GetChild(3);

        // Atur posisi awal base
        base1.position = new Vector3(0, base1.position.y, base1.position.z);
        batasAtas1.position = new Vector3(0, batasAtas1.position.y, base1.position.z);
        base2.position = new Vector3(baseWidth, base1.position.y, base1.position.z); // Sesuaikan dengan posisi base1 di sumbu y
        batasAtas2.position = new Vector3(baseWidth, batasAtas1.position.y, base1.position.z);
    }

    private void Update()
    {
        if (gameManager.gamePhase == GamePhase.Gameplay)
        {
            // Geser kedua base ke kiri (tetap di posisi y yang sama)
            base1.position += Vector3.left * Time.deltaTime;
            base2.position += Vector3.left * Time.deltaTime;
            batasAtas1.position += Vector3.left * Time.deltaTime;
            batasAtas2.position += Vector3.left * Time.deltaTime;

            // Pindahkan base pertama ke depan jika keluar dari layar
            if (base1.position.x <= -baseWidth)
            {
                base1.position = new Vector3(base2.position.x + baseWidth, base1.position.y, base1.position.z); // Pastikan y tetap sama
                batasAtas1.position = new Vector3(base2.position.x + baseWidth, batasAtas1.position.y, base1.position.z);
                SwapReferencesBase();
            }

            // Pindahkan base kedua ke depan jika keluar dari layar
            if (base2.position.x <= -baseWidth)
            {
                base2.position = new Vector3(base1.position.x + baseWidth, base2.position.y, base2.position.z); // Pastikan y tetap sama
                batasAtas2.position = new Vector3(base1.position.x + baseWidth, batasAtas2.position.y, base2.position.z);
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

        temp = batasAtas1;
        batasAtas1 = batasAtas2;
        batasAtas2 = temp;
    }
}
