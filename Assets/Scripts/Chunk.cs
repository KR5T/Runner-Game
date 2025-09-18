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
        int laneIndex = Random.Range(0, lane.Length);
        Vector3 spawnPosition = new Vector3(lane[laneIndex], transform.position.y, transform.position.z);
        Instantiate(fencePrefab, spawnPosition, Quaternion.identity, this.transform);
    }
}
