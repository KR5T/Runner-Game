using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float obstacleSpawnTime = 5f;
    public Transform obstacleParent;
    public float spawnWidth = 5f;

    void Start()
    {
        StartCoroutine(spawnObstacleRoutine());
    }

    IEnumerator spawnObstacleRoutine()
    {
        while (true)
        {
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)]; 
            yield return new WaitForSeconds(obstacleSpawnTime);
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnWidth, spawnWidth), transform.position.y, transform.position.z);
            Instantiate(obstaclePrefab, spawnPosition, Random.rotation, obstacleParent);
        }
    }

   
}
