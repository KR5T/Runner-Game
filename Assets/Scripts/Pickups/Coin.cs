using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Pickups
{
    protected override void OnPickup()
    {
        Debug.Log("add 100 points");
    }
}
