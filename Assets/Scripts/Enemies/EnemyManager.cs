using UnityEngine;
using UnityEngine.Pool;

public class EnemyManager : MonoBehaviour
{
    public EnemyMovement enemyMovement { get; private set; }
    public EnemyHealth enemyHealth { get; private set; }
    public EnemyCollisionDamage enemyCollisionDamage { get; private set; }
    public EnemyLootDropManager enemyLootDropManager { get; private set; }

    IObjectPool<GameObject> enemyPool;

    private void Awake()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        enemyHealth = GetComponent<EnemyHealth>();
        enemyCollisionDamage = GetComponent<EnemyCollisionDamage>();
        enemyLootDropManager = GetComponent<EnemyLootDropManager>();
    }

    public void SetEnemyObjectPool(IObjectPool<GameObject> pool)
    {
        enemyPool = pool;
    }

    public void ReturnToPool(GameObject enemy)
    {
        enemyPool.Release(enemy);
    }
}
