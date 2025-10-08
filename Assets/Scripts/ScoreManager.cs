using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public GameManager gameManager;
    public TMP_Text scoreText;
    int score = 0;

    public void IncreaseScore(int scoreAmount)
    {
        if (gameManager.GameOver)
            return;
        score += scoreAmount;
        scoreText.text = score.ToString();
    }
}
