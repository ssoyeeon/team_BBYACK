using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Text scoreText;

    private int startY = 3;
    private int score = 0;

    private void Start()
    {
        UpdateScoreText();
    }


    public void PlayerMoved(int currentY)
    {
        while (currentY >= startY)
        {
            startY += 12;
            score++;
        }

        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "현재 스코어 : " + score.ToString();
    }

}
