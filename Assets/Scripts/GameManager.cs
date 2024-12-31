using UnityEngine;
using UnityEngine.SceneManagement;
public enum GamePhase
{
    MainMenu, Gameplay, GameOver
}
public class GameManager : MonoBehaviour
{
    public GamePhase gamePhase;
    public GameObject pipePrefab;
    public GameObject basePrefab;
    public GameObject backgroundPrefab;

    public int score = 0;

    private void Start()
    {
        gamePhase = GamePhase.MainMenu;
    }
    public void StartGame()
    {
        gamePhase = GamePhase.Gameplay;
        SpawnPipe();
    }
    public void GameOver()
    {
        gamePhase = GamePhase.GameOver;
    }
    public void SpawnPipe()
    {
        Instantiate(pipePrefab);
    }
    public void ObstaclePassed()
    {
        score = score + 1;
        SpawnPipe();
    }
    public void Retry()
    {
        SceneManager.LoadScene(0);
    }
}
