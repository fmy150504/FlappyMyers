using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject gameOver;
    public GameObject mainMenu;
    public GameObject score;

    private void Awake()
    {
        gameManager = Object.FindFirstObjectByType<GameManager>();
    }

    private void Update()
    {
        if (gameManager.gamePhase == GamePhase.MainMenu)
        {
            ShowMainMenu();
        } else if (gameManager.gamePhase == GamePhase.Gameplay)
        {
            ShowGameplay();
        } else if (gameManager.gamePhase == GamePhase.GameOver)
        {
            ShowGameOver();
        }
    }

    public void ShowMainMenu()
    {
        gameOver.SetActive(false);
        mainMenu.SetActive(true);
        score.SetActive(false);
    }
    public void ShowGameplay()
    {
        gameOver.SetActive(false);
        mainMenu.SetActive(false);
        score.SetActive(true);
    }
    public void ShowGameOver()
    {
        gameOver.SetActive(true);
        mainMenu.SetActive(false);
        score.SetActive(false);
    }
}
