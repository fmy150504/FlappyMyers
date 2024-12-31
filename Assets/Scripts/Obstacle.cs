using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameManager gameManager;
    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Myers>())
        {
            gameManager.GameOver();
        }
    }
}
