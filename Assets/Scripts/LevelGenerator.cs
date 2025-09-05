using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] int startChunkAmount = 12;
    [SerializeField] Transform chunkParent;
    public float chunkLength = 10f;
    [SerializeField] float moveSpeed = 8f;

    //GameObject[] chunks = new GameObject[12];
    List<GameObject> chunks = new List<GameObject>();

    void Start()
    {
        SpawnStartingChunks();
    }

    void Update()
    {
        MoveChunks();
    }

    void SpawnStartingChunks(){
        for (int i = 0; i < startChunkAmount; i++)
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
        float spawnPositionZ = CalculatePositionZ();
        Vector3 chunkSpawnPos = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);
        GameObject newChunk = Instantiate(chunkPrefab, chunkSpawnPos, Quaternion.identity, chunkParent);

        chunks.Add(newChunk);
    }

    float CalculatePositionZ(){
        float spawnPositionZ;

        if (chunks.Count == 0){
            spawnPositionZ = transform.position.z;
        }
        else{
            //spawnPositionZ = transform.position.z + (i * chunkLength);
            spawnPositionZ = chunks[chunks.Count-1].transform.position.z+chunkLength;
        }

        return spawnPositionZ;
    }

    void MoveChunks(){
        for(int i=0; i<chunks.Count ; i++){
            GameObject chunk = chunks[i];

            chunk.transform.Translate(Vector3.back*moveSpeed*Time.deltaTime);

            if(chunk.transform.position.z <= Camera.main.transform.position.z - chunkLength){
                chunks.Remove(chunk);
                Destroy(chunk);
                SpawnChunk();
            }
        }
    }
}
