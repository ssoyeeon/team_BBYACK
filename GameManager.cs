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
        // ���� ���¸� ���ӿ��� ���·� ��ȯ
        isGameOver = true;
        // ���� ���� �ؽ�Ʈ ���� ������Ʈ�� Ȱ��ȭ
        gameoverText.SetActive(true);

        // BestTime Ű�� ����� ���������� �ְ� ��� ��������
        float bestScore = PlayerPrefs.GetFloat("BestScore");

        // ���������� �ְ� ��Ϻ��� ���� ���� �ð��� �� ũ�ٸ�
        if (survivalTime > bestScore)
        {
            // �ְ� ��� ���� ���� ���� �Ⱓ ������ ����
            bestScore = survivalTime;
            // ����� �ְ� ����� BestTime Ű�� ����
            PlayerPrefs.SetFloat("BestScore", bestScore);
            // PlayerPrefs�� ������� ����
            PlayerPrefs.Save();
        }

        recordText.text = "�ְ� ����: " + (int)bestScore;
    }



}
