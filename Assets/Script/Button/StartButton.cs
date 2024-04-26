using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public Button startbutton;

    // Start is called before the first frame update
    private void Awake()
    {
        startbutton = GetComponent<Button>();
        startbutton.onClick.AddListener(GameStart);
    }

    void GameStart()
    {
        SceneManager.LoadScene("C.GameScene");
    }
} 

