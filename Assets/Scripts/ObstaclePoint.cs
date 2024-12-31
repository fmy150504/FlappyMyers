using UnityEngine;

public class ObstaclePoint : MonoBehaviour
{
    public GameManager gameManager;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    private void Start()
    {
        Vector3 newPosition = transform.position;

        newPosition.y = Random.Range(-0.25f, 0.75f);
        transform.position = newPosition;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Myers>())
        {
            gameManager.ObstaclePassed();
        }
    }
}
