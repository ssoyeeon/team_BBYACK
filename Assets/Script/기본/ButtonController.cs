using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;

public class ButtonController : MonoBehaviour
{
    public string[] SceneList = new string[20];     //string 리스트를 만듭니다.
    
     public void StageMain(int number)              //넘버로 가져와요
    {
        SceneManager.LoadScene(SceneList[number]);  //리스트에 쓴 이름의 씬을 가져옵니다.
    }

    public void GameSet(int num)        //숫자로 가져와요
    {
        Application.Quit();             //게임 종료~!
    }
}
