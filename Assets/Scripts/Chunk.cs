using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public GameObject fencePrefab;
    public float[] lane = { -2.5f, 0, 2.5f };
    
    void Start()
    {
        SpawnFence();
    }

    void SpawnFence()
    {
        List<int> availableLane = new List<int> { 1, 2, 3 };
        int fancesToSpawn = Random.Range(0,3);

        for (int i = 0; i < fancesToSpawn; i++)
        {
            int randomLaneIndex = Random.Range(0, availableLane.Count);
            int selectedIndex = availableLane[randomLaneIndex];
            availableLane.RemoveAt(randomLaneIndex);
            
            
            Vector3 spawnPosition = new Vector3(lane[randomLaneIndex], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPosition, Quaternion.identity, this.transform);
        }

        
    }
}
