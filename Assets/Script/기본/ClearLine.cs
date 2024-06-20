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
            //Unlock(); �ر� �Լ� ���߱�~ 
            SceneManager.LoadScene("C.Clear");
            Clear = true;
        }
    }

    //private void Unlock()
    //{
    //    //UnlockedStage�� �� ���� �̸� bulidIndex�� ���� �ε����� ���Ŀ� ,
    //    //GetActiveScene Ȱ��ȭ �� ���� ��
    //    if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("UnlockedStage")) ;
    //    {
    //        PlayerPrefs.SetInt("UnlockedStage", PlayerPrefs.GetInt("UnlockedStage", 1) + 1);    //�ε����� 1�� ���ؼ� ���� ���� ��� ���� ��Ŵ!
    //        PlayerPrefs.Save();
    //    }
    //}
}
