using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerSpawner : MonoBehaviour
{
    public GameObject lazerPrefab;
    public float lazerSpawnChance = .6f;
    List<int> indexNumber = new List<int> { 0, 1, 2 };
    float[] lane = { -2.5f, 0, 2.5f };

    void Start()
    {
        spawnLazer();
    }

    private void spawnLazer()
    {
        int spawnCount = Random.Range(0, lane.Length);

        if (lazerSpawnChance < Random.value)
            return;
        for(int i=0; i<spawnCount; i++)
        {
            int selectedIndex = selectIndex();
            Vector3 newPosition = new Vector3(lane[selectedIndex], transform.position.y, transform.position.z);
            Instantiate(lazerPrefab, newPosition, Quaternion.identity, this.transform);
        }
    }

    private int selectIndex()
    {
        int randomindex = Random.Range(0, indexNumber.Count);
        int selectedIndex = indexNumber[randomindex];
        indexNumber.RemoveAt(randomindex);
        return selectedIndex;
    }
}
