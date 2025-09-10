using System;

public static class EventManager
{
    public static Action OnEnemyDeath;

    public static Action<float> OnHealthChange;

    public static Action<GameStateManager.GameState> OnGameStateChange;
}
