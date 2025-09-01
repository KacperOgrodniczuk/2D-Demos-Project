using System;

public static class EventManager
{
    public static Action<int> OnEnemyDeath;

    public static Action<float> OnHealthChange;
}
