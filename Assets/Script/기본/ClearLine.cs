using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ClearLine : MonoBehaviour
{
    private GameObject Mergee;      //Merge ¿ÀºêÁ§Æ®

    public void OnCollisionEnter(Collision collision)      //´ê¾ÒÀ» ¶§
    {
        Mergee = GameObject.Find("Sphere");     //ÀÌ¸§ÀÌ SphereÀÓ.
        if (Mergee == null)                     //¸ÓÁö°¡ null ÀÏ ¶§ Å¬¸®¾î ¾À ¶ç¿öÁà¿ä
        {
            SceneManager.LoadScene("C.Clear");
        }

        

        if (collision.gameObject.tag == "RightPlayer")      //RightPlayer°¡ ´ê¾Ò¾î¿ä!
        {
            SceneManager.LoadScene("RightWin");             //RightWin¾À ¶ç¿ó´Ï´Ù.
        }
        if (collision.gameObject.tag == "LeftPlayer")       //leftPlayer°¡ ´ê¾Ò¾î¿ä!
        {
            SceneManager.LoadScene("LeftWin");              //leftWin¾À ¶ç¿ó´Ï´Ù.
        }
    }
}
