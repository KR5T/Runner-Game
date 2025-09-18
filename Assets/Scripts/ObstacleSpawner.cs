using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float obstacleSpawnTime = 5f;

    void Start()
    {
        StartCoroutine(spawnObstacleRoutine());
    }

    IEnumerator spawnObstacleRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(obstacleSpawnTime);
            Instantiate(obstaclePrefab, transform.position, Random.rotation);
        }
    }

   
}
