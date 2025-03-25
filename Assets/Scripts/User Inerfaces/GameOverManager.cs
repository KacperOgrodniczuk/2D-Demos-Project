using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;  // Reference to your Game Over UI panel

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }

    public void RetryGame()
    {
        Time.timeScale = 1f; // Unpause the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
