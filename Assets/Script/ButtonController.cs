using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public string[] SceneList = new string[20];

    public void StageMain(int number)
    {
        SceneManager.LoadScene(SceneList[number]);
    }
}
