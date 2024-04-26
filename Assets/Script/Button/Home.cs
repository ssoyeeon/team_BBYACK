using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    public Button homeButton;

    // Start is called before the first frame update
    void Start()
    {
        homeButton.onClick.AddListener(GameStart);
    }
   
    // Update is called once per frame
    void Update()
    { 

    }

    void GameStart()
    {
        // "StartScene" æ¿¿∏∑Œ ¿Ãµø
        SceneManager.LoadScene("C.StartScene");
    }
}
