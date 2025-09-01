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
    public bool isPaused { get; private set; } = false;
    public bool isGameOver { get; private set; } = false;

    public static UIManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        EventManager.OnHealthChange += UpdateHealthUI;
    }

    private void OnDisable()
    {
        EventManager.OnHealthChange -= UpdateHealthUI;
    }

    private void UpdateHealthUI(float newValue)
    {
        healthSlider.value = newValue;
    }

    public void ShowUpgradeUI()
    {
        upgradeUI.SetActive(true);
    }

    public void HideUpgradeUI()
    { 
        upgradeUI.SetActive(false);
    }

    public void ShowGameOverUI()
    { 
        isGameOver = true;
        gameOverUI.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void RestartGame()
    {
        isGameOver = false;
        gameOverUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void TogglePauseMenuUI()
    { 
        isPaused = !isPaused;
        pauseMenuUI.SetActive(isPaused);
        Time.timeScale = isPaused ? 0.0f : 1.0f;
    }

    public void QuitGame() => Application.Quit();
}
