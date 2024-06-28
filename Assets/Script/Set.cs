using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Set : MonoBehaviour
{
    public Button[] buttons;

    void Bu(int num)
    {
        if (num == 1)
        {
            Application.Quit();
        }

        if(num == 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
