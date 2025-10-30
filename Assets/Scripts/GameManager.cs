using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    LevelGenerator levelGenerator;
    public TMP_Text tmp;
    public GameObject gameOverText;
    public float startTime = 30;

    public float durationTime;
    bool gameOver = false;

    // public bool GameOver{get { return gameOver; }}
    public bool GameOver => gameOver;

    void Start()
    {
        durationTime = startTime;
        levelGenerator = FindAnyObjectByType<LevelGenerator>();
    }

    void Update()
    {
        DecreaseTime();
    }

    void GameOverMethod()
    {
        gameOver = true;
        gameOverText.SetActive(true);
        Time.timeScale = .1f;
        Invoke("GameOverMenu", .5f); 
    }

    void DecreaseTime()
    {
        if (gameOver == true) return;

        durationTime -= Time.deltaTime;
        tmp.text = durationTime.ToString("F1");
        
        if (durationTime < 0 || levelGenerator.moveSpeed < 6)
        {
            GameOverMethod();
        }
    }

    public void IncreaseTime()
    {
        durationTime += 10;
    }

    private void GameOverMenu()
    {
        SceneManager.LoadScene("GameOverMenu");
    }
}
