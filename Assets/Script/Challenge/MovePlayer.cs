    using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using DG.Tweening;
using UnityEditor;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{
    public GameObject[] mergeObjects;
    public int mergeLevel = 0;


    private bool canMove = true;

    private bool gamePlay = true;

    public GameObject rander;
    public Rigidbody _Rigidbody;
    public int Force = 100;
    public int Force1 = 20;
    public float moveSpeed = 5f;
    public float moveSpeed1 = 5f;

    public float StartTime = 3;
    public TMP_Text startFont;

    public Text scoreText;
    private int score = 0;

    public int Score => score;

    public Vector3 minPosition = new Vector3(-15f, -10f, -15f);
    public Vector3 maxPosition = new Vector3(15f, 100f, 15f);
    public Vector3 originalPosition = new Vector3(0f, 0f, 0f);

    private static MovePlayer instance;

    public static MovePlayer Instance => instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

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

        //스타트 타임
        if (StartTime <= 0)
        {
            StartTime = 0;
            startFont.text = "";
            _Rigidbody.useGravity = true;

            if (canMove == true)
            {
                //마우스 좌클릭 시에 왼쪽 위로 올라감
                if (Input.GetMouseButtonDown(0))
                {
                    _Rigidbody.velocity = Vector3.zero;
                    _Rigidbody.AddForce(Vector3.up * Force, ForceMode.VelocityChange);
                    _Rigidbody.AddForce(Vector3.left * Force1, ForceMode.Impulse);
                }

                //마우스 우클릭 시에 오른쪽 위로 올라감
                else if (Input.GetMouseButtonDown(1))
                {
                    _Rigidbody.velocity = Vector3.zero;
                    _Rigidbody.AddForce(Vector3.up * Force, ForceMode.VelocityChange);
                    _Rigidbody.AddForce(Vector3.right * Force1, ForceMode.Impulse);
                }
            }

            //x,y,z 써놓은 좌표 이상 나가면 재시작
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
        if (collision != null && gamePlay == true && collision.gameObject.tag != "Muge")
        {
            canMove = false;
            gamePlay = false;

            _Rigidbody.velocity = Vector3.zero;

            transform.position += new Vector3(0.0f, 0.0f, -3.0f);
            
            rander.transform.DOPunchScale(Vector3.one * 0.3f, 0.7f).OnComplete(() =>
            {
                SceneManager.LoadScene("C.GameOverScene");
                Debug.Log(collision.gameObject.name);
            });
        }

        //if (gameObject.tag == "Muge")
        if (collision.gameObject.tag == "Muge")
        {
            collision.gameObject.SetActive(false);
            Debug.Log("충돌 체크 완료");
            // 합체 버섯과 충돌시 mergeLevel 카운트 변수의 값을 1증가시킴
            //mergeLevel = mergeLevel + 1;
            //mergeLevel += 1;

            // 충돌로 인한 합체시 현재단계 오브젝트 Off, 다음 레벨 오브젝트 On
            // 현재 단계 오브젝트 Off
            mergeObjects[mergeLevel].SetActive(false);

            ++mergeLevel;
            mergeLevel = Mathf.Clamp(mergeLevel, 0, mergeObjects.Length - 1);
            // 다음 레벨 오브젝트 On
            mergeObjects[mergeLevel].SetActive(true);

            for (int i = 0; i < mergeObjects.Length; ++i)
            {
                if (mergeLevel == i)
                {
                    mergeObjects[i].SetActive(true);
                }
                
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Score")
        {
            Destroy(other.gameObject);
            score++;
            scoreText.text = "Score: " + score;
        }
    }
}
    