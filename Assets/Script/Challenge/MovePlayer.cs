using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using DG.Tweening;
using UnityEditor;

public class MovePlayer : MonoBehaviour
{
    private bool canMove = true;

    public GameObject rander;
    public Rigidbody _Rigidbody;
    public int Force = 100;
    public int Force1 = 20;
    public float moveSpeed = 5f;
    public float moveSpeed1 = 5f;

    public float StartTime = 3;
    public TMP_Text startFont;

    public Vector3 minPosition = new Vector3(-15f, -10f, -15f);
    public Vector3 maxPosition = new Vector3(15f, 100f, 15f);
    public Vector3 originalPosition = new Vector3(0f,0f,0f);

    // Start is called before the first frame update
    void Start()
    {
        _Rigidbody.velocity = Vector3.zero;
        _Rigidbody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        StartTime -= Time.deltaTime;
        startFont.text = StartTime.ToString("F0");

        //��ŸƮ Ÿ��
        if (StartTime <= 0)
        {
            StartTime = 0;
            startFont.text = "";
            _Rigidbody.useGravity = true;

            if (canMove == true)
            {
                //���콺 ��Ŭ�� �ÿ� ���� ���� �ö�
                if (Input.GetMouseButtonDown(0))
                {
                    _Rigidbody.velocity = Vector3.zero;
                    _Rigidbody.AddForce(Vector3.up * Force, ForceMode.VelocityChange);
                    _Rigidbody.AddForce(Vector3.left * Force1, ForceMode.Impulse);
                }

                //���콺 ��Ŭ�� �ÿ� ������ ���� �ö�
                else if (Input.GetMouseButtonDown(1))
                {
                    _Rigidbody.velocity = Vector3.zero;
                    _Rigidbody.AddForce(Vector3.up * Force, ForceMode.VelocityChange);
                    _Rigidbody.AddForce(Vector3.right * Force1, ForceMode.Impulse);
                }
            }

            //x,y,z ����� ��ǥ �̻� ������ �����
            Vector3 clasmpedPosition = transform.position;
            clasmpedPosition.x = Mathf.Clamp(clasmpedPosition.x, minPosition.x, maxPosition.x);
            clasmpedPosition.y = Mathf.Clamp(clasmpedPosition.y, minPosition.y, maxPosition.y);
            clasmpedPosition.z = Mathf.Clamp(clasmpedPosition.z, minPosition.z, maxPosition.z);

            if (transform.position != clasmpedPosition)
            {
                gameObject.transform.position = new Vector3(0.0f, 1.0f, 0.0f);
                SceneManager.LoadScene("C.GameOverScene");
            }
        }


    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision != null)
        {
            canMove = false;
            _Rigidbody.velocity = Vector3.zero;
            rander.transform.DOPunchScale(Vector3.one, 0.7f).OnComplete(() =>
            {

                SceneManager.LoadScene("C.GameOverScene");
                Debug.Log(collision.gameObject.name);
            });
        }
    }
}
