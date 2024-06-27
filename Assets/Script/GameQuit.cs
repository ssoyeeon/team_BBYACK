using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameQuit : MonoBehaviour
{
    public GameObject Canvas_Pause;
    public GameObject btn_Pause;
    public GameObject btn_ReStart;
    public GameObject btn_Continue;
    public GameObject btn_GameEnd;

    public string thisScene;

    //메뉴 혹은 멈춤 클릭했을 때
    public void Pause()
    {
        thisScene = SceneManager.GetActiveScene().name;

        Time.timeScale = 0f;
        Canvas_Pause.SetActive(true);
    }

    public void ReStart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(thisScene);
    }    

    public void Continue()
    {
        Canvas_Pause.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GameEnd()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    } 
        
}
