using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fight : MonoBehaviour
{
    public Rigidbody _Rigidbody;

    public float StartTime = 3;
    public TMP_Text startFont;

    public GameObject Clear;

    void Start()
    {
        _Rigidbody.velocity = Vector3.zero;
        _Rigidbody.useGravity = false;
    }

    void Update()
    {
        StartTime -= Time.deltaTime;
        startFont.text = StartTime.ToString("F0");

        if (StartTime <= 0)
        {
            StartTime = 0;
            startFont.text = "";
            _Rigidbody.useGravity = true;
            if (Input.GetKeyDown(KeyCode.A))
            {
                _Rigidbody.velocity = Vector3.zero;
                _Rigidbody.AddForce(Vector3.up * 23, ForceMode.VelocityChange);
                _Rigidbody.AddForce(Vector3.left * 4, ForceMode.Impulse);
            }

            //마우스 우클릭 시에 오른쪽 위로 올라감
            else if (Input.GetKeyDown(KeyCode.D))
            {
                    _Rigidbody.velocity = Vector3.zero;
                    _Rigidbody.AddForce(Vector3.up * 23, ForceMode.VelocityChange);
                    _Rigidbody.AddForce(Vector3.right * 4, ForceMode.Impulse);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (CompareTag("LeftPlayer"))
        {
            _Rigidbody.velocity = Vector3.zero;
            this.transform.position = new Vector3(0.0f, 0.0f, -10.0f);
            SceneManager.LoadScene("LeftWin");
        }

        if (gameObject == Clear)
        {
            SceneManager.LoadScene("LeftWin");
        }
    }
}
