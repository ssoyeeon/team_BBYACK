using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merge : MonoBehaviour
{
    Rigidbody2D rigidbody2D;      //2D 강체를 불러온다.

    public SpriteRenderer spriteRenderer;

    void Awake()                                          //시작하기전 소스 단계에서부터 셋팅
    {
        rigidbody2D = GetComponent<Rigidbody2D>();        //강체를 가져온다.
        rigidbody2D.simulated = false;                    //생성될때는 시뮬레이팅 되지 않는다.
        spriteRenderer = GetComponent<SpriteRenderer>();  //해당 오브젝트의 스프라이트 랜더러 접근
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collision)             //Trigger 충돌 중일 때
    {
        if (collision != null)
        {

        }
            
        
    }
}
