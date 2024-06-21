using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ClearLine : MonoBehaviour
{
    private GameObject Mergee;

    public void OnCollisionEnter(Collision collision)
    {
        Mergee = GameObject.Find("Sphere");
        if (Mergee == null)
        {
            Debug.Log("Ω««‡«‡");
            SceneManager.LoadScene("C.Clear");
        }

        

        if (collision.gameObject.tag == "RightPlayer")
        {
            SceneManager.LoadScene("RightWin");
        }
        if (collision.gameObject.tag == "LeftPlayer")
        {
            SceneManager.LoadScene("LeftWin");
        }
    }
}
