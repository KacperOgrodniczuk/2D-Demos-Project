using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgradeManager : MonoBehaviour
{
    public PlayerAttackManager attackManager;
    public PlayerMovementManager movementManager;

    [Header("Stat multipliers")]
    public float attackDamageMultiplier = 2f;
    public float attackRateMultiplier = 0.9f;
    public float movementSpeedMultiplier = 1.1f;

    int totalKills = 0;
    int killsToNextUpgrade = 10;
    float killsToNextUpgradeMultiplier = 1.1f;

    private void Awake()
    {
        EventManager.OnEnemyDeath += OnEnemyDeath;
    }

    void OnEnemyDeath(int score)
    { 
        totalKills += score;

        if (totalKills >= killsToNextUpgrade)
        {
            GameStateManager.Instance.SetGameState(GameStateManager.GameState.SelectingUpgrade);
        }
    }

    public void IncreaseDamage()
    {
        attackManager.attackDamage *= attackDamageMultiplier;
        FinaliseUpgrade();
    }

    public void IncreaseMovementSpeed()
    {
        movementManager.moveSpeed += movementSpeedMultiplier;
        FinaliseUpgrade();
    }

    public void IncreaseAttackRate()
    { 
        attackManager.attackRate *= attackRateMultiplier;
        FinaliseUpgrade();
    }

    void FinaliseUpgrade()
    {
        killsToNextUpgrade = killsToNextUpgrade + Mathf.RoundToInt(killsToNextUpgrade * killsToNextUpgradeMultiplier);
        GameStateManager.Instance.SetGameState(GameStateManager.GameState.Playing);
    }
}