using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    int score = 0;

    public void IncreaseScore(int scoreAmount)
    {
        score += scoreAmount;
        scoreText.text = score.ToString();
    }
}
