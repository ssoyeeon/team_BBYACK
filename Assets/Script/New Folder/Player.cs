using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Net.Sockets;
using UnityEditor;

public class Player : MonoBehaviour
{
    private static Player instance;

    public static Player Instance => instance;

    //머지 버섯
    private MushroomColor playerMushroomColor;
    public GameObject[] mergeObjects;
    private int mergeLevel = 0;

    //움직임
    private bool canMove;
    private bool gamePlay;
    public Rigidbody rig;
    private int upforce = 23;
    private int rightforce = 4;

    //시간
    public float StartTime = 3;
    public TMP_Text startFont;

    //스코어
    public TMP_Text scoreText;
    private int score = 0;
    private int Score => score;

    //거리
    private Vector2 min = new Vector3(-15f, -10f, -15f);
    private Vector2 max = new Vector3(15f, 1000f, 15f);

    //무적
    private bool mu;
    private float mu_time = 2;
    public GameObject shield;

    void Awake()
    {
       if(instance == null)
          instance = this;

       else
       Destroy(gameObject);
    }

    void Start()
    {
        rig.velocity = Vector3.zero;
        rig.useGravity = false;
        shield.SetActive(false);
    }


    void Update()
    {
        StartTime -= Time.deltaTime;
        startFont.text = StartTime.ToString("F0");

        if(StartTime <= 0)
        {
            StartTime = 0;
            startFont.text = "";
            rig.useGravity = true;
            canMove = true;
        }
        mumu();
        GamePlay();
        StartGame();
        Out();
    }

    void StartGame()
    {

    }
    void GamePlay()
    {
        if (canMove == true)
        {
            //마우스 좌클릭 시에 왼쪽 위로 올라감
            if (Input.GetMouseButtonDown(0))
            {
                rig.velocity = Vector3.zero;
                rig.AddForce(Vector3.up * upforce, ForceMode.VelocityChange);
                rig.AddForce(Vector3.left * rightforce, ForceMode.Impulse);
            }

            //마우스 우클릭 시에 오른쪽 위로 올라감
            else if (Input.GetMouseButtonDown(1))
            {
                rig.velocity = Vector3.zero;
                rig.AddForce(Vector3.up * upforce, ForceMode.VelocityChange);
                rig.AddForce(Vector3.right * rightforce, ForceMode.Impulse);
            }
        }
    }    

    void Out()
    {
        //x,y,z 써놓은 좌표 이상 나가면 재시작
        Vector3 clasmpedPosition = transform.position;
        clasmpedPosition.x = Mathf.Clamp(clasmpedPosition.x, min.x, max.x);
        clasmpedPosition.y = Mathf.Clamp(clasmpedPosition.y, min.y, max.y);

        if (transform.position != clasmpedPosition)
        {
            Die();
        }
    }

    void mumu()
    {
        mu_time -= Time.deltaTime;
        if(mu_time <= 0)
        {
            mu = false;
            shield.SetActive(false);
        }

        if(mu == true)
        {
            shield.SetActive(true);
        }
    }

    private MushroomColor GetNextColor(MushroomColor currentColor)
    {
        switch (currentColor)
        {
            case MushroomColor.Orange:
                return MushroomColor.yellow;
            case MushroomColor.yellow:
                return MushroomColor.Green;
            case MushroomColor.Green:
                return MushroomColor.SkyBlue;
            case MushroomColor.SkyBlue:
                return MushroomColor.Blue;
            case MushroomColor.Blue:
                return MushroomColor.purple;
            case MushroomColor.purple:
                return MushroomColor.pink;
            case MushroomColor.pink:
                return MushroomColor.dahong;
            case MushroomColor.dahong:
                return MushroomColor.darkwhite;
            default:
                return MushroomColor.Orange;
        }
    }
    
    void Die()
    {
        canMove = false;
        SceneManager.LoadScene("C.GameOverScene");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (mu)
            return;

        if (other != null && other.gameObject.tag != "Muge")
        {
            Die();
        }

        Mushroom mushroomComponent = other.gameObject.GetComponentInParent<Mushroom>();

        if (mushroomComponent != null)
        {
            MushroomColor collidedMushroomColor = mushroomComponent.Color;

            if (playerMushroomColor == collidedMushroomColor)
            {
                playerMushroomColor = GetNextColor(playerMushroomColor);
            }
            else
            {
                SceneManager.LoadScene("C.GameOverScene");
            }
        }

        if (other.gameObject.tag == "Muge")
        {
            mu = true;
            mu_time = 2f;

            Destroy(other.gameObject);

            mergeObjects[mergeLevel].SetActive(false);

            ++mergeLevel;
            mergeLevel = Mathf.Clamp(mergeLevel, 0, mergeObjects.Length - 1);

            mergeObjects[mergeLevel].SetActive(true);

            for (int i = 0; i < mergeObjects.Length; ++i)
            {
                if (mergeLevel == i)
                {
                    mergeObjects[i].SetActive(true);
                }

            }

        }

        if (other.gameObject.tag == "Score")
        {
            Destroy(other.gameObject);
            score++;
            scoreText.text = "Score: " + score;
        }
    }
}
