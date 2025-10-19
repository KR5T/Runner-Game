using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    public Animator animator;
    const string hitString= "Hit";
    float collisionCooldown = 1f;
    float cooldownTimer =0;
    float hitSpeedChanger = -2f;

    LevelGenerator levelGenerator;

    void Update()
    {
        cooldownTimer = Time.time;
    }

    void Start()
    {
        levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (cooldownTimer < collisionCooldown) return;
        levelGenerator.ChangeChunkMoveSpeed(hitSpeedChanger);
        animator.SetTrigger(hitString);
        cooldownTimer = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            animator.SetTrigger(hitString);
        }
    }
}
