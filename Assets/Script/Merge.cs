using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merge : MonoBehaviour
{
    Rigidbody2D rigidbody2D;      //2D ��ü�� �ҷ��´�.

    public SpriteRenderer spriteRenderer;

    void Awake()                                          //�����ϱ��� �ҽ� �ܰ迡������ ����
    {
        rigidbody2D = GetComponent<Rigidbody2D>();        //��ü�� �����´�.
        rigidbody2D.simulated = false;                    //�����ɶ��� �ùķ����� ���� �ʴ´�.
        spriteRenderer = GetComponent<SpriteRenderer>();  //�ش� ������Ʈ�� ��������Ʈ ������ ����
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collision)             //Trigger �浹 ���� ��
    {
        if (collision != null)
        {

        }
            
        
    }
}
