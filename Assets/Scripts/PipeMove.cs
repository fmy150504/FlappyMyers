using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public GameManager gameManager;
    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    private void Update()
    {
        if (gameManager.gamePhase == GamePhase.Gameplay)
        {
            transform.position = transform.position + Vector3.left * Time.deltaTime;
        }

        if (transform.position.x <= -2f)
        {
            Destroy(gameObject);
        }
    }
}
