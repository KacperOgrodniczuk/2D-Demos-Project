using System.Collections;
using UnityEngine;

public class EndlessSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // The prefab to spawn
    public Transform spawnPoint;     // The point where objects will be spawned

    float spawnInterval = 2f;       // Time between spawns in seconds
    float minimumSpawnInterval = 1f;    // The minimal amount of time between enemies spawning.
    float intervalDecrease = 0.1f;  // How much does the spawn time decrease by.

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

            // Wait between spawn times
            yield return new WaitForSeconds(spawnInterval);

            //calculate the new spawn time.
            spawnInterval = Mathf.Max(minimumSpawnInterval, spawnInterval - intervalDecrease);
        }
    }
}
