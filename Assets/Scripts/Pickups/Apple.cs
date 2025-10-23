using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : Pickups
{
    LevelGenerator levelGenerator;
    public float powerUpSpeed = 3f;

    public void Init( LevelGenerator levelGenerator)
    {
        this.levelGenerator = levelGenerator;
    }

    protected override void OnPickup()
    {
        levelGenerator.ChangeChunkMoveSpeed(powerUpSpeed);
    }
}
