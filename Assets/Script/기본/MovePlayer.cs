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
    private MushroomColor playerMushroomColor;      //MushroomColor ��ũ��Ʈ���� ������

    public GameObject[] mergeObjects;       //���� ������Ʈ ����Ʈ
    public int mergeLevel = 0;              //���� ����

    private bool canMove = true;            //������ �� ����

    private bool gamePlay = true;           //���� ����

    public GameObject rander;               //��Ʈ���� ���� �÷��̾ ������
    public Rigidbody _Rigidbody;            //�÷��̾��� ������ٵ� - �߷�
    public int Force = 100;                 //���� �ö� ��
    public int Force1 = 20;                 //��,��� �ö� ��

    public float StartTime = 3;             //��ŸƮ Ÿ�� ���� 
    public TMP_Text startFont;              //��ŸƮ

    public TMP_Text scoreText;              //���ھ�
    private int score = 0;                  //���ھ� ���� ���� 0 ��

    public int Score => score;                  //Score�� score�� �����ҰԿ�~

    //�ִ� �̵� �Ÿ�
    public Vector3 minPosition = new Vector3(-15f, -10f, -15f);         
    public Vector3 maxPosition = new Vector3(15f, 100f, 15f);
    public Vector3 originalPosition = new Vector3(0f, 0f, 0f);

    private static MovePlayer instance;         //����ƽ���� �ٲ㼭 ��𼭵��� ���� �� �ְ� �ҰԿ�~

    public static MovePlayer Instance => instance;      //instance�� �������Կ�~

    public bool mu;                 //���� Ÿ�� Ȱ��ȭ ��Ȱ��ȭ
    public float mu_time;           //���� �ð�
    public GameObject muspr;        //�� ��������Ʈ �����ðԿ�~

    public bool stoptime;           //���� �� �Ͻ����� Ȱ��ȭ ��Ȱ��ȭ

    public GameObject GameUI;      //�Ͻ����� ȭ�� �� ��� UI

    //��ŸƮ �����ϱ� ���� ���� �ҰԿ�~
    void Awake()
    {
        if (instance == null)      
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        _Rigidbody.velocity = Vector3.zero;     //������ٵ� �ʱ�ȭ �ϰ� �����ҰԿ�~
        _Rigidbody.useGravity = false;          //���� ���� �� �����ϴ�. �׷���Ƽ false �س����Կ�~
        muspr.SetActive(false);                 //���� �ϴ� fasle
        stoptime = false;                       //�Ͻ������� �翬�ϰԵ� ��Ȱ��ȭ �س����ϴ�.
        GameUI.SetActive(false);                //UI ��������~
    }

    void Update()
    {     
        StartTime -= Time.deltaTime;                    //��� ��ǻ�Ϳ��� �Ȱ��� Time.deltaTime�� ���ϴ��
        startFont.text = StartTime.ToString("F0");      //��ŸƮ�� �־����~



        mu_time -= Time.deltaTime;                      //��� ��ǻ�Ϳ��� �Ȱ��� Time.deltaTime�� ���~
        if (mu_time <= 0)                               //���� �ð��� ������ 
        {            
            mu = false;                                //���� ��Ȱ��ȭ
            muspr.SetActive(false);                    //�� ��������Ʈ�� ��Ȱ��ȭ
        }

        if( mu == true )                                //���� Ÿ���� ����Ǹ�
        {
            muspr.SetActive(true);                      //�� ��������Ʈ Ȱ��ȭ
        }

        //��ŸƮ Ÿ��
        if (StartTime <= 0)                             //��ŸƮ Ÿ���� 0�� ���ų� ������
        {
            StartTime = 0;                              //0���� �������ְ�
            startFont.text = "";                        //�ؽ�Ʈ�� �ƹ��͵� ����� �ʰ� ""�� ���ϴ�.
            _Rigidbody.useGravity = true;               //�÷��� �� �� �ְ� �߷� Ȱ��ȭ

            if (canMove == true && tag == "Player")     //������ �� �ִ� ���°� �±װ� �÷��̾��̸�
            {               
                //���콺 ��Ŭ�� �ÿ� ���� ���� �ö�
                if (Input.GetMouseButtonDown(0))                                            //���� Ŭ���ϸ�
                {
                    _Rigidbody.velocity = Vector3.zero;                                     //�߷� ����3 �ʱ�ȭ ���ֱ���
                    _Rigidbody.AddForce(Vector3.up * Force, ForceMode.VelocityChange);      //����ŭ ���� �ö󰩴ϴ� ForceMode.VelocityChange�� �����̴� ���
                    _Rigidbody.AddForce(Vector3.left * Force1, ForceMode.Impulse);          //����ŭ �������� �ö󰩴ϴ�  ForceMode.Impulse�� �����̴� ���
                }

                //���콺 ��Ŭ�� �ÿ� ������ ���� �ö�
                else if (Input.GetMouseButtonDown(1))
                {
                    _Rigidbody.velocity = Vector3.zero;
                    _Rigidbody.AddForce(Vector3.up * Force, ForceMode.VelocityChange);
                    _Rigidbody.AddForce(Vector3.right * Force1, ForceMode.Impulse);
                }

                if(Input.GetKeyDown(KeyCode.Escape))        //ESC ������
                {
                    if (stoptime == false)                  //stoptime�� ��Ȱ��ȭ ���¸�
                    {
                        stoptime = true;                    //true�� �ٲ��ֱ���
                        Time.timeScale = 0f;                //timeScale�� 0���� �ؼ� �Ͻ����� �����ݴϴ�
                        GameUI.SetActive(true);             //UI ��
                        return;                             //����~
                    }

                    if(stoptime == true)                    //stoptime�� Ȱ��ȭ ���¸�
                    {
                        Time.timeScale = 1f;                //timeScale�� 1�� ���� ��� �����ֱ���
                        stoptime = false;                   //false�� �ٲ��ݴϴ�
                        GameUI.SetActive(false);            //UI ��
                        return;                             //����~~
                    }
                }
            }

            //x,y,z ����� ��ǥ �̻� ������ �����
            Vector3 clasmpedPosition = transform.position;
            clasmpedPosition.x = Mathf.Clamp(clasmpedPosition.x, minPosition.x, maxPosition.x);     //�ִ�,�ּ� x
            clasmpedPosition.y = Mathf.Clamp(clasmpedPosition.y, minPosition.y, maxPosition.y);     //�ִ�,�ּ� y

            if (transform.position != clasmpedPosition)          //clasmpedPosition�� ����� ���
            {
                SceneManager.LoadScene("C.GameOverScene");      //���� ���� �����ݴϴ�.
            }
        }
    }

    private MushroomColor GetNextColor(MushroomColor currentColor)      // �ӽ��� �÷��� ���� ������ �ٲ��ݴϴ�.
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
            default:                                    //����Ʈ ���� ����������
                return MushroomColor.Orange;
        }
    }

    private void OnCollisionEnter(Collision collision)      //�浹���� ���.
    {
        if (mu)                                             //mu�� ���� �ٷ� �������ݴϴ�. ��Ƶ� �� �װԿ�.
            return;

        if (collision != null && gamePlay == true && collision.gameObject.tag != "Muge")        //�ݸ����̰�, ���� �÷������ε�, Muge �±װ� �ƴϸ�!
        {
            canMove = false;            //�� ������
            gamePlay = false;           //���� ����

            _Rigidbody.velocity = Vector3.zero;         //�� ���ֹ���!

            transform.position += new Vector3(0.0f, 0.0f, -3.0f);       //�ٸ� ��ü�� �� ��� z ��ǥ�� �Ű��ݴϴ�. ( �� ���� ���. ) 

            rander.transform.DOPunchScale(Vector3.one * 0.3f, 0.7f).OnComplete(() =>  //���׻��� �ϸ鼭 �������� �մϴ�. ������
            {
                SceneManager.LoadScene("C.GameOverScene");                              //�� ģ������ ����˴ϴ�. ���� ������ ����ֱ���
            });
        }
    }

    private void OnTriggerEnter(Collider other)                 //Ʈ���ŷ� ����� �� (����ġ�� ����)
    {
        if (other.gameObject.tag == "Score")                   //���� �±װ� Score�� ��
        {
            Destroy(other.gameObject);                          //�� ���� ���� ��� Destroy ���� �����ְ��
            score++;                                            // ���� �÷��ֱ���
            scoreText.text = "Score: " + score;                 //score �������� 
        }

        // �浹�� ���� ������Ʈ�� �÷��̾� ������Ʈ�� �ڽ� ������Ʈ���� Ȯ��
        Mushroom mushroomComponent = other.gameObject.GetComponentInParent<Mushroom>();

        if (mushroomComponent != null)          //mushroomComponent�� null�� �ƴ� �� 
        {
            // Mushroom ��ũ��Ʈ�� ���� ���� ������ ������ ������
            MushroomColor collidedMushroomColor = mushroomComponent.Color;

            // ������ ������ �÷��̾� ������ ����� ������ �÷��̾� ������ ������ ����
            if (playerMushroomColor == collidedMushroomColor)
            {
                // ���� ������ ������ ������
                playerMushroomColor = GetNextColor(playerMushroomColor);
            }
            else
            {
                // ������ ������ �÷��̾� ������ ����� �ٸ� ��쿡�� ���� ����
                SceneManager.LoadScene("C.GameOverScene");
            }
        }

        //if (gameObject.tag == "Muge")
        if (other.gameObject.tag == "Muge")
        {
            mu = true;
            mu_time = 1.5f;

            Destroy(other.gameObject);
            // ��ü ������ �浹�� mergeLevel ī��Ʈ ������ ���� 1������Ŵ

            // �浹�� ���� ��ü�� ����ܰ� ������Ʈ Off, ���� ���� ������Ʈ On
            // ���� �ܰ� ������Ʈ Off
            mergeObjects[mergeLevel].SetActive(false);

            ++mergeLevel;
            mergeLevel = Mathf.Clamp(mergeLevel, 0, mergeObjects.Length - 1);
            // ���� ���� ������Ʈ On
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

