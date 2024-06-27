using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ClearLine : MonoBehaviour
{
    private GameObject Mergee;      //Merge ������Ʈ

    public void OnCollisionEnter(Collision collision)      //����� ��
    {
        Mergee = GameObject.Find("Sphere");     //�̸��� Sphere��.
        if (Mergee == null)                     //������ null �� �� Ŭ���� �� ������
        {
            SceneManager.LoadScene("C.Clear");
        }

        

        if (collision.gameObject.tag == "RightPlayer")      //RightPlayer�� ��Ҿ��!
        {
            SceneManager.LoadScene("RightWin");             //RightWin�� ���ϴ�.
        }
        if (collision.gameObject.tag == "LeftPlayer")       //leftPlayer�� ��Ҿ��!
        {
            SceneManager.LoadScene("LeftWin");              //leftWin�� ���ϴ�.
        }
    }
}
