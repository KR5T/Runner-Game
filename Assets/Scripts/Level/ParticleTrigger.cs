using UnityEngine;

public class ParticleTrigger : MonoBehaviour
{
    public ParticleSystem particle;
    const string playerString = "Player";

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerString))
        {
            Debug.Log("Player trigger’a girdi");
            particle.Play();
        }
    }
}

