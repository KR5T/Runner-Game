using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    public Animator animator;
    const string hitString= "Hit";
    float collisionCooldown = 1f;
    float cooldownTimer =0;

    void Update()
    {
        cooldownTimer = Time.time;
    }

    void OnCollisionEnter(Collision other)
    {
        if (cooldownTimer < collisionCooldown) return;
        animator.SetTrigger(hitString);
        cooldownTimer = 0;
    }
}
