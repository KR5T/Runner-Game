using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Pickups
{
    public int scoreAmount = 100;
    ScoreManager scoreManager;

    public void Init(ScoreManager scoreManager)
    {
        this.scoreManager = scoreManager;
    }

    protected override void OnPickup()
    {
        scoreManager.IncreaseScore(scoreAmount);
    }
}
