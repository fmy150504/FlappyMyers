using UnityEngine;
using UnityEngine.InputSystem; // Tambahkan namespace Input System

public class Myers : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody2D myersRigidbody2D;
    private Animator animator;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        myersRigidbody2D.gravityScale = 0;
    }

    private void Update()
    {
        if (gameManager.gamePhase == GamePhase.Gameplay)
        {
            myersRigidbody2D.gravityScale = 1;
            animator.SetBool("IsGameplay", true);

            // Menggunakan Input System untuk mendeteksi lompat
            if (Keyboard.current.spaceKey.wasPressedThisFrame ||
                Touchscreen.current?.primaryTouch.press.isPressed == true)
            {
                Jump();
            }

            animator.SetBool("IsFalling", myersRigidbody2D.linearVelocity.y < 0);
        }
        else
        {
            myersRigidbody2D.gravityScale = 0f;
            myersRigidbody2D.linearVelocity = Vector2.zero;
            animator.SetBool("IsGameplay", false);
        }
    }

    private void Jump()
    {
        myersRigidbody2D.linearVelocity = Vector2.up * 3;
        animator.SetTrigger("Jump");
    }
}
