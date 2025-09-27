using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public GameObject fencePrefab;
    public GameObject applePrefab;
    public GameObject coinPrefab;
    public float appleSpawnChance = .3f;
    public float CoinSpawnChance = .5f;
    public float[] lane = { -2.5f, 0, 2.5f };

    List<int> availableLane = new List<int> { 0, 1, 2 };

    void Start()
    {
        SpawnFence();
        SpawnApple();
        SpawnCoin();
    }

    void SpawnFence()
    {
        int fancesToSpawn = Random.Range(0, lane.Length);

        for (int i = 0; i < fancesToSpawn; i++)
        {
            if (availableLane.Count <= 0) { break; }

            int selectedLane = SelectLane();

            Vector3 spawnPosition = new Vector3(lane[selectedLane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPosition, Quaternion.identity, this.transform);
        }

    }

    void SpawnApple()
    {
        if (availableLane.Count <= 0 || Random.value > appleSpawnChance) { return; }

        int selectedLane = SelectLane();

        Vector3 spawnPosition = new Vector3(lane[selectedLane], transform.position.y, transform.position.z);
        Instantiate(applePrefab, spawnPosition, Quaternion.identity, this.transform);
    }

    void SpawnCoin()
    {
        if (availableLane.Count <= 0 || Random.value > CoinSpawnChance) { return; }

        int selectedLane = SelectLane();
        int coinCount = Random.Range(3, 5);
        Vector3 posZ = new Vector3(0,0, transform.position.z);

        for (int i = 0; i < coinCount; i++)
        {
            Vector3 spawnPosition = new Vector3(lane[selectedLane], transform.position.y, posZ.z);
            Instantiate(coinPrefab, spawnPosition, Quaternion.identity, this.transform);
            posZ.z += 1;
        }
    }

    int SelectLane()
    {
        int randomLaneIndex = Random.Range(0, availableLane.Count);
        int selectedLane = availableLane[randomLaneIndex];
        availableLane.RemoveAt(randomLaneIndex);
        return selectedLane;
    }
}
