using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // You can change the key
        {
            GameStateManager.GameState newState;

            if (GameStateManager.Instance.CurrentState == GameStateManager.GameState.Playing)
                newState = GameStateManager.GameState.Paused;
            else if (GameStateManager.Instance.CurrentState == GameStateManager.GameState.Paused)
                newState = GameStateManager.GameState.Playing;
            else
                return;     //if in another menu or any other state don't allow the player to pause the game.

            GameStateManager.Instance.SetGameState(newState);
        }
    }
}
