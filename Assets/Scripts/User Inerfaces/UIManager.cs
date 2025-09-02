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

    public static UIManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            // For now we ignore the below, but in the future it needs to not destroy itself and dynamically grab references
            // On scene reloads, and handle null checks
            //transform.parent = null;    //unparent the object. Parent is for organisation in hierarchy. DontDestroyOnLoad can't be called on non root objects.    
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

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
