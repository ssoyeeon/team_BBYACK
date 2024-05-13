using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BackGroundPunch : MonoBehaviour
{
    
    float CountTime;
    public float Power = 0.1f;
    

    // Start is called before the first frame update
    void Start()
    {
        
        CountTime = Random.Range(0 , 3);

    }

    // Update is called once per frame
    void Update()
    {
        CountTime -= Time.deltaTime;

        if (CountTime <= 0)
        {
            CountTime = Random.Range (0 , 3);
            transform.DOPunchScale(Vector3.one*Power, 0.5f );
        }
    }
}
