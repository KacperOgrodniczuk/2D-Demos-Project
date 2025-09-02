using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    public enum GameState
    { 
        Playing,
        Paused,
        SelectingUpgrade,
        GameOver
    }

    public GameState CurrentState { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        SetGameState(GameState.Playing);
    }

    public void SetGameState(GameState gameState)
    {
        CurrentState = gameState;
        EventManager.OnGameStateChange?.Invoke(gameState);
    }
}
