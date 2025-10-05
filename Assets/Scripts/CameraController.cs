using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    CinemachineVirtualCamera cinemachineCamera;
    public float MaxFOV = 120f;
    public float MinFOV = 60f;
    public float zoomDuration = 1f;
    public float zoomSpeed = 5f;
    public ParticleSystem speedUpParticle;

    void Awake()
    {
        cinemachineCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void changeCameraFOV(float speedAmount)
    {
        StopAllCoroutines();
        StartCoroutine(ChangeFOVRoutine(speedAmount));

        if (speedAmount > 0)
        {
            speedUpParticle.Play();
        }
    }

    //most common pattern
    IEnumerator ChangeFOVRoutine(float speedAmount)
    {
        float startFOV = cinemachineCamera.m_Lens.FieldOfView;
        float targetFOV = Mathf.Clamp(startFOV + speedAmount * zoomSpeed, MinFOV, MaxFOV);

        float elapsedTime = 0f;

        while (elapsedTime < zoomDuration)
        {
            float t = elapsedTime / zoomDuration;
            elapsedTime += Time.deltaTime;

            cinemachineCamera.m_Lens.FieldOfView = Mathf.Lerp(startFOV, targetFOV, t);
            yield return null;
        }
    }
}
