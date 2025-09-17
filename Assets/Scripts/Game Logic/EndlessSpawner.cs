using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class EndlessSpawner : MonoBehaviour
{
    public static EndlessSpawner Instance { get; private set; }

    [Header("Enemy Spawning")]
    [Tooltip("The prefab of the enemy to spawn.")]
    public GameObject enemyPrefab; // The prefab to spawn
    [Tooltip("Possible positions for the enemies to be spawned.")]
    public Transform[] spawnPoints;

    [Header("Difficulty Scaling")]
    [Tooltip("The initial number of enemies that can be active at once")]
    public int initialMaxEnemies = 5;
    [Tooltip("The number of enemies to add to the max count every minute")]
    public int enemyCapIncreasePerMinute = 2;
    [Tooltip("The time inseconds between each spawn check.")]
    public float spawnInterval = 2f;       // Time between spawns in seconds

    private IObjectPool<GameObject> enemyPool;

    private int activeEnemyCount = 0;
    private float missionTime = 0f;
    private int currentMaxEnemies;

    private void Awake()
    {
        // This is a singleton in case we need to access current enemy pool. e.g. for traps spawning enemies
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        enemyPool = new ObjectPool<GameObject>(CreateEnemy, OnGetEnemy, OnReleaseEnemy, OnDestroyEnemy);

        EventManager.OnEnemyDeath += OnEnemyDeath;
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemiesContinuously());
    }

    GameObject CreateEnemy()
    {
        GameObject newEnemy = Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity);
        newEnemy.GetComponent<EnemyManager>().SetEnemyObjectPool(enemyPool);
        return newEnemy;
    }

    void OnGetEnemy(GameObject enemy)
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        enemy.transform.position = spawnPoints[spawnPointIndex].position;
        enemy.SetActive(true);
        enemy.GetComponent<EnemyManager>().enemyHealth.ResetHealth();
        activeEnemyCount++;
    }

    void OnReleaseEnemy(GameObject enemy)
    { 
        enemy.SetActive(false);
    }

    void OnDestroyEnemy(GameObject enemy)
    {
        Destroy(enemy);
    }

    private void OnEnemyDeath()
    { 
        activeEnemyCount--;
    }

    private IEnumerator SpawnEnemiesContinuously()
    {
        while (true)
        {
            // This is the core logic for the endless wave system.
            missionTime += spawnInterval;
            currentMaxEnemies = initialMaxEnemies + (int)(missionTime / 60) * enemyCapIncreasePerMinute;

            if (activeEnemyCount < currentMaxEnemies)
            {
                // Get an enemy from the pool if below the max enemy count.
                enemyPool.Get();
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void OnDisable()
    {
        EventManager.OnEnemyDeath -= OnEnemyDeath;
    }
}
