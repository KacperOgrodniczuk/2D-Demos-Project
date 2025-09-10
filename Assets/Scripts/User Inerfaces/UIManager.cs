using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class UIManager : MonoBehaviour
{
    [Header("UI references")]
    public GameObject pauseMenuUI;
    public GameObject gameOverUI;
    public GameObject upgradeUI;
    public Slider healthSlider;

    private void OnEnable()
    {
        EventManager.OnHealthChange += UpdateHealthUI;
        EventManager.OnGameStateChange += OnGameStateChange;
    }

    private void OnDisable()
    {
        EventManager.OnHealthChange -= UpdateHealthUI;
        EventManager.OnGameStateChange -= OnGameStateChange;
    }

    private void UpdateHealthUI(float newValue)
    {
        healthSlider.value = newValue;
    }

    private void OnGameStateChange(GameStateManager.GameState gameState)
    {
        switch (gameState)
        {
            case GameStateManager.GameState.Playing:
                HandlePlayingState();
                break;
            case GameStateManager.GameState.Paused:
                HandlePausedState();
                break;
            case GameStateManager.GameState.SelectingUpgrade:
                HandleSelectingUpgradeState();
                break;
            case GameStateManager.GameState.GameOver:
                HandleGameOverState();
                break;
        }
    }

    void HandlePlayingState()
    { 
        pauseMenuUI.SetActive(false);
        upgradeUI.SetActive(false);
        gameOverUI.SetActive(false);
        Time.timeScale = 1.0f;
    }

    void HandlePausedState()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    void HandleSelectingUpgradeState()
    { 
        upgradeUI.SetActive(true);
        Time.timeScale = 0f;
    }

    void HandleGameOverState()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    // Button functions
    public void ResumeGame()
    {
        GameStateManager.Instance.SetGameState(GameStateManager.GameState.Playing);
    }

    public void RestartGame()
    {
        GameStateManager.Instance.SetGameState(GameStateManager.GameState.Playing);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame() => Application.Quit();
}
