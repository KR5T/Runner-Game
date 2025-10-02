using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : Pickups
{
    protected override void OnPickup()
    {
        Debug.Log("Power Up!");
    }
}
