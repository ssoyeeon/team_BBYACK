using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public Button obj;
    public float checkTime = 0;
    private float time = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PressTo());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            time = 0.1f;

            Invoke("GameStart", 1);
        }
    }

    private IEnumerator PressTo()
    {
        checkTime = 0;

        while(checkTime <= time) 
        {
            checkTime += Time.deltaTime;
            yield return null;
        }

        obj.enabled = false;

        checkTime = 0;

        while (checkTime <= time)
        {
            checkTime += Time.deltaTime;
            yield return null;
        }

        obj.enabled = true;

        StartCoroutine(PressTo());
    }

    private void GameStart()
    {
        SceneManager.LoadScene("GameScene");
    }
} 

