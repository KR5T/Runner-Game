using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : Pickups
{
    LevelGenerator levelGenerator;
    public float powerUpSpeed = 3f;

    void Start()
    {
        levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }

    protected override void OnPickup()
    {
        Debug.Log("Power Up!");
        levelGenerator.ChangeChunkMoveSpeed(powerUpSpeed);
    }

    
}
