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

    /// <summary>
    /// Sets the current state of the game and broadcasts a change event.
    /// </summary>
    /// <param name="gameState">The new state to set for the game.</param>
    public void SetGameState(GameState gameState)
    {
        CurrentState = gameState;
        EventManager.OnGameStateChange?.Invoke(gameState);
    }
}
