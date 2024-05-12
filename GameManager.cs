using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{
    public GameObject gameoverText;
    public Text recordText;

    private float survivalTime;
    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        survivalTime = 0;
        isGameOver = false;
    }

    public void EndGame()
    {
        // 현재 상태를 게임오버 상태로 전환
        isGameOver = true;
        // 게임 오버 텍스트 게임 오브젝트를 활성화
        gameoverText.SetActive(true);

        // BestTime 키로 저장된 이전까지의 최고 기록 가져오기
        float bestScore = PlayerPrefs.GetFloat("BestScore");

        // 이전까지의 최고 기록보다 현재 생존 시간이 더 크다면
        if (survivalTime > bestScore)
        {
            // 최고 기록 값을 현재 생존 기간 값으로 변경
            bestScore = survivalTime;
            // 변경된 최고 기록을 BestTime 키로 저장
            PlayerPrefs.SetFloat("BestScore", bestScore);
            // PlayerPrefs에 변경사항 저장
            PlayerPrefs.Save();
        }

        recordText.text = "최고 점수: " + (int)bestScore;
    }



}
