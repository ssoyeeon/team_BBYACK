using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int startY = 3;
    private int score = 0;

    private void Start()
    {
        Debug.Log("초기 스코어 : " + score);
    }


    public void PlayerMoved(int currentY)
    {
        while (currentY >= startY)
        {
            startY += 12;
            score++;
        }

        Debug.Log("현재 스코어 : " + score);
    }
    
}
