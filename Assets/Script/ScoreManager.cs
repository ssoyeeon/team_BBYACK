using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text score_Text;

    private int score;
    private int bestScore;

    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        score = MovePlayer.Instance.Score;
        score_Text.text = "Score: " + score.ToString();

        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        score_Text.text = "Best Score : " + bestScore.ToString();


        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
            score_Text.text = "Best Score: " + bestScore.ToString();
        }
    }
}
