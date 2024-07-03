using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using DG.Tweening;
using UnityEditor;
using UnityEngine.UI;
using DG.Tweening.Core.Easing;
using UnityEngine.Audio;

public class MovePlayer : MonoBehaviour
{
    private MushroomColor playerMushroomColor;      //MushroomColor 스크립트에서 가져옴

    public GameObject[] mergeObjects;       //머지 오브젝트 리스트
    public int mergeLevel = 0;              //머지 레벨

    private bool canMove = true;            //움직일 수 있음

    private bool gamePlay = true;           //게임 실행

    public GameObject rander;               //두트윈을 위해 플레이어를 가져옴
    public Rigidbody _Rigidbody;            //플레이어의 리지드바디 - 중력
    public int Force = 100;                 //위로 올라갈 힘
    public int Force1 = 20;                 //좌,우로 올라갈 힘

    public float StartTime = 3;             //스타트 타임 설정 
    public TMP_Text startFont;              //스타트

    public TMP_Text scoreText;              //스코어
    private int score = 0;                  //스코어 점수 시작 0 점

    public int Score => score;                  //Score를 score로 저장할게염~

    //최대 이동 거리
    public Vector3 minPosition = new Vector3(-15f, -10f, -15f);         
    public Vector3 maxPosition = new Vector3(15f, 100f, 15f);
    public Vector3 originalPosition = new Vector3(0f, 0f, 0f);

    private static MovePlayer instance;         //스태틱으로 바꿔서 어디서든지 만질 수 있게 할게요~

    public static MovePlayer Instance => instance;      //instance로 가져갈게요~

    public bool mu;                 //무적 타임 활성화 비활성화
    public float mu_time;           //무적 시간
    public GameObject muspr;        //방어막 스프라이트 가져올게요~

    public bool stoptime;           //멈출 때 일시정지 활성화 비활성화

    public GameObject GameUI;      //일시정지 화면 때 띄울 UI

    //스타트 시작하기 전에 먼저 할게요~
    void Awake()
    {
        if (instance == null)      
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        _Rigidbody.velocity = Vector3.zero;     //리지드바디 초기화 하고 시작할게요~
        _Rigidbody.useGravity = false;          //아직 시작 안 했읍니다. 그래비티 false 해놓을게요~
        muspr.SetActive(false);                 //방어막도 일단 fasle
        stoptime = false;                       //일시정지는 당연하게도 비활성화 해놓습니다.
        GameUI.SetActive(false);                //UI 꺼놔야죠~
    }

    void Update()
    {     
        StartTime -= Time.deltaTime;                    //모든 컴퓨터에서 똑같게 Time.deltaTime을 씁니당당
        startFont.text = StartTime.ToString("F0");      //스타트에 넣어줘요~



        mu_time -= Time.deltaTime;                      //모든 컴퓨터에서 똑같게 Time.deltaTime을 써요~
        if (mu_time <= 0)                               //무적 시간이 끝나면 
        {            
            mu = false;                                //무적 비활성화
            muspr.SetActive(false);                    //방어막 스프라이트도 비활성화
        }

        if( mu == true )                                //무적 타임이 실행되면
        {
            muspr.SetActive(true);                      //방어막 스프라이트 활성화
        }

        //스타트 타임
        if (StartTime <= 0)                             //스타트 타임이 0과 같거나 작으면
        {
            StartTime = 0;                              //0으로 고정해주고
            startFont.text = "";                        //텍스트에 아무것도 띄우지 않게 ""만 씁니다.
            _Rigidbody.useGravity = true;               //플레이 할 수 있게 중력 활성화

            if (canMove == true && tag == "Player")     //움직일 수 있는 상태고 태그가 플레이어이면
            {               
                //마우스 좌클릭 시에 왼쪽 위로 올라감
                if (Input.GetMouseButtonDown(0))                                            //왼쪽 클릭하면
                {
                    _Rigidbody.velocity = Vector3.zero;                                     //중력 벡터3 초기화 해주구요
                    _Rigidbody.AddForce(Vector3.up * Force, ForceMode.VelocityChange);      //힘만큼 위로 올라갑니다 ForceMode.VelocityChange는 움직이는 모양
                    _Rigidbody.AddForce(Vector3.left * Force1, ForceMode.Impulse);          //힘만큼 왼쪽으로 올라갑니다  ForceMode.Impulse는 움직이는 모양
                }

                //마우스 우클릭 시에 오른쪽 위로 올라감
                else if (Input.GetMouseButtonDown(1))
                {
                    _Rigidbody.velocity = Vector3.zero;
                    _Rigidbody.AddForce(Vector3.up * Force, ForceMode.VelocityChange);
                    _Rigidbody.AddForce(Vector3.right * Force1, ForceMode.Impulse);
                }

                if(Input.GetKeyDown(KeyCode.Escape))        //ESC 누르면
                {
                    if (stoptime == false)                  //stoptime이 비활성화 상태면
                    {
                        stoptime = true;                    //true로 바꿔주구요
                        Time.timeScale = 0f;                //timeScale을 0으로 해서 일시정지 시켜줍니다
                        GameUI.SetActive(true);             //UI 켜
                        return;                             //리턴~
                    }

                    if(stoptime == true)                    //stoptime이 활성화 상태면
                    {
                        Time.timeScale = 1f;                //timeScale을 1로 만들어서 재생 시켜주구요
                        stoptime = false;                   //false로 바꿔줍니다
                        GameUI.SetActive(false);            //UI 꺼
                        return;                             //리턴~~
                    }
                }
            }

            //x,y,z 써놓은 좌표 이상 나가면 재시작
            Vector3 clasmpedPosition = transform.position;
            clasmpedPosition.x = Mathf.Clamp(clasmpedPosition.x, minPosition.x, maxPosition.x);     //최대,최소 x
            clasmpedPosition.y = Mathf.Clamp(clasmpedPosition.y, minPosition.y, maxPosition.y);     //최대,최소 y

            if (transform.position != clasmpedPosition)          //clasmpedPosition을 벗어났을 경우
            {
                SceneManager.LoadScene("C.GameOverScene");      //게임 오버 시켜줍니다.
            }
        }
    }

    private MushroomColor GetNextColor(MushroomColor currentColor)      // 머쉬룸 컬러를 다음 색으로 바꿔줍니다.
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
            default:                                    //디폴트 값은 오렌지에용
                return MushroomColor.Orange;
        }
    }

    private void OnCollisionEnter(Collision collision)      //충돌했을 경우.
    {
        if (mu)                                             //mu일 때는 바로 리턴해줍니다. 닿아도 안 죽게요.
            return;

        if (collision != null && gamePlay == true && collision.gameObject.tag != "Muge")        //콜리전이고, 게임 플레이중인데, Muge 태그가 아니면!
        {
            canMove = false;            //못 움직여
            gamePlay = false;           //게임 중지

            _Rigidbody.velocity = Vector3.zero;         //힘 없애버렷!

            transform.position += new Vector3(0.0f, 0.0f, -3.0f);       //다른 물체와 안 닿게 z 좌표를 옮겨줍니다. ( 한 번만 닿게. ) 

            rander.transform.DOPunchScale(Vector3.one * 0.3f, 0.7f).OnComplete(() =>  //뽀잉뽀잉 하면서 내려가게 합니다. 끝나면
            {
                SceneManager.LoadScene("C.GameOverScene");                              //이 친구들이 실행됩니다. 게임 오버씬 띄워주구요
            });
        }
    }

    private void OnTriggerEnter(Collider other)                 //트리거로 닿았을 때 (지나치는 느낌)
    {
        if (other.gameObject.tag == "Score")                   //게임 태그가 Score일 때
        {
            Destroy(other.gameObject);                          //한 번만 점수 얻게 Destroy 삭제 시켜주고요
            score++;                                            // 점수 올려주구요
            scoreText.text = "Score: " + score;                 //score 띄워줘야죠 
        }

        // 충돌한 게임 오브젝트가 플레이어 오브젝트의 자식 오브젝트인지 확인
        Mushroom mushroomComponent = other.gameObject.GetComponentInParent<Mushroom>();

        if (mushroomComponent != null)          //mushroomComponent가 null이 아닐 때 
        {
            // Mushroom 스크립트가 있을 때만 버섯의 색상을 가져옴
            MushroomColor collidedMushroomColor = mushroomComponent.Color;

            // 버섯의 색상이 플레이어 버섯의 색상과 같으면 플레이어 버섯의 색상을 변경
            if (playerMushroomColor == collidedMushroomColor)
            {
                // 다음 순서의 색상을 가져옴
                playerMushroomColor = GetNextColor(playerMushroomColor);
            }
            else
            {
                // 버섯의 색상이 플레이어 버섯의 색상과 다른 경우에는 게임 오버
                SceneManager.LoadScene("C.GameOverScene");
            }
        }

        //if (gameObject.tag == "Muge")
        if (other.gameObject.tag == "Muge")
        {
            mu = true;
            mu_time = 1.5f;

            Destroy(other.gameObject);
            // 합체 버섯과 충돌시 mergeLevel 카운트 변수의 값을 1증가시킴

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
}

