using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ClearLine : MonoBehaviour
{
    public static ClearLine Instance;
    [SerializeField] private GameObject Muge;

    public bool Clear;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            //Unlock(); 해금 함수 가야금~ 
            SceneManager.LoadScene("C.Clear");
            Clear = true;
        }
    }

    //private void Unlock()
    //{
    //    //UnlockedStage는 걍 변수 이름 bulidIndex로 빌드 인덱스를 가쳐옴 ,
    //    //GetActiveScene 활성화 된 현재 씬
    //    if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("UnlockedStage")) ;
    //    {
    //        PlayerPrefs.SetInt("UnlockedStage", PlayerPrefs.GetInt("UnlockedStage", 1) + 1);    //인덱스에 1을 더해서 다음 씬을 잠금 해제 시킴!
    //        PlayerPrefs.Save();
    //    }
    //}
}
