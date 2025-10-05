using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Pickups
{
    public int scoreAmount = 100;
    ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    protected override void OnPickup()
    {
        scoreManager.IncreaseScore(scoreAmount);
    }
}
