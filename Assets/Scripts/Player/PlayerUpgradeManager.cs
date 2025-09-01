using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgradeManager : MonoBehaviour
{
    PlayerAttackManager attackManager;
    PlayerMovementManager movementManager;

    [Header("Stat multipliers")]
    public float attackDamageMultiplier = 2f;
    public float attackRateMultiplier = 0.9f;
    public float movementSpeedMultiplier = 1.1f;

    int totalKills = 0;

    private void Awake()
    {
        attackManager = GetComponent<PlayerAttackManager>();
        movementManager = GetComponent<PlayerMovementManager>();

        EventManager.OnEnemyDeath += OnEnemyDeath;
    }

    void OnEnemyDeath(int score)
    { 
        totalKills += score;

        if (totalKills % 10 == 0)
        {
            UIManager.Instance.ShowUpgradeUI();
        }
    }

    public void IncreaseDamage()
    {
        attackManager.attackDamage *= attackDamageMultiplier;
        UIManager.Instance.HideUpgradeUI();
    }

    public void IncreaseMovementSpeed()
    {
        movementManager.moveSpeed += movementSpeedMultiplier;
        UIManager.Instance.HideUpgradeUI();
    }

    public void IncreaseAttackRate()
    { 
        attackManager.attackRate *= attackRateMultiplier;
        UIManager.Instance.HideUpgradeUI();
    }
}