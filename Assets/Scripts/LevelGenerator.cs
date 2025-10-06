using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] Transform chunkParent;
    public CameraController cameraController;
    public ScoreManager scoreManager;
    [Header("Level Settings")]
    [Tooltip("Do not  change the chunk length unless chunk prefab size reflects change")]
    [SerializeField] int startChunkAmount = 12;
    public float chunkLength = 10f;
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float minMoveSpeed = 2f;
    

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

    public void ChangeChunkMoveSpeed(float speedAmount)
    {
        moveSpeed += speedAmount;

        if (moveSpeed < minMoveSpeed)
        {
            moveSpeed = minMoveSpeed;
        }

        Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, Physics.gravity.z - speedAmount);

        cameraController.changeCameraFOV(speedAmount);
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
        GameObject newChunkGO = Instantiate(chunkPrefab, chunkSpawnPos, Quaternion.identity, chunkParent);

        chunks.Add(newChunkGO);

        Chunk newChunk = newChunkGO.GetComponent<Chunk>();
        newChunk.Init(this, scoreManager);
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
