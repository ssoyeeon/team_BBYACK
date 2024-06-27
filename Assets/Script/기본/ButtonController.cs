using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;

public class ButtonController : MonoBehaviour
{
    public string[] SceneList = new string[20];     //string ����Ʈ�� ����ϴ�.
    
     public void StageMain(int number)              //�ѹ��� �����Ϳ�
    {
        SceneManager.LoadScene(SceneList[number]);  //����Ʈ�� �� �̸��� ���� �����ɴϴ�.
    }

    public void GameSet(int num)        //���ڷ� �����Ϳ�
    {
        Application.Quit();             //���� ����~!
    }
}
