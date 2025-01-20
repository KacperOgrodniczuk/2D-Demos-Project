using System.Collections;
using UnityEngine;

public class EndlessSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // The prefab to spawn
    public Transform spawnPoint;     // The point where objects will be spawned
    
    float spawnInterval = 2f; // Time between spawns in seconds
    float minSpawnInterval = 1f;
    float intervalDecrease = 0.1f;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {

        while (true)
        {
            if (objectToSpawn != null && spawnPoint != null)
            {
                Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
            }
            else
            {
                Debug.LogWarning("Object to spawn or spawn point is not set.");
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
