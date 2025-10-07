using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TMP_Text tmp;
    public GameObject gameOverText;
    public float startTime = 30;
    float durationTime;
    bool gameOver = false;

    void Start()
    {
        durationTime = startTime;
    }

    void Update()
    {
        DecreaseTime();
    }

    void GameOver()
    {
        gameOver = true;
        gameOverText.SetActive(true);
        Time.timeScale = .1f;
    }

    void DecreaseTime()
    {
        if (gameOver == true) return;
        durationTime -= Time.deltaTime;
        tmp.text = durationTime.ToString("F1");
        if (durationTime < 0)
        {
            GameOver();
        }
    }

}
