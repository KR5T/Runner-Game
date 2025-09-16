using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    int obstacleCount = 0;
    public float obstacleSpawnTime = 5f;

    void Start()
    {
        StartCoroutine(spawnObstacleRoutine());
    }

    IEnumerator spawnObstacleRoutine()
    {
        while (obstacleCount < 5 )
        {
            yield return new WaitForSeconds(obstacleSpawnTime);
            Instantiate(obstaclePrefab, transform.position, quaternion.identity);
            obstacleCount++;
        }
    }

   
}
