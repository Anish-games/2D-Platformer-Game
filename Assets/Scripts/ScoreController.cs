using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int score = 0;
    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        RefreshScore();
    }
    public void scoreIncrement(int increment)
    {
        score += increment;
        RefreshScore();
    }

    private void RefreshScore()
    {
        scoreText.text = "Score : " + score;
    }
}
