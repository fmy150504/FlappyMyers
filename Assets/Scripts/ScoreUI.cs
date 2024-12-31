using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour 
{
    public GameManager gameManager;
    public Text scoreText;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    private void Update()
    {
        scoreText.text = gameManager.score.ToString();
    }
}
