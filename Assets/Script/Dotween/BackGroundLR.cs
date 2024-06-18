using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG;
using DG.Tweening;

public class BackGroundLR : MonoBehaviour
{
    public int num;
    public int L = 10;
    public int U = 1;
    public Vector3 R;

    void Start()
    {
        if (num == 1)
        {
            this.transform.DOMoveX(L, 30).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
        }

        if (num == 2)
        {
            this.transform.DOMoveY(U,17).SetEase(Ease.Linear);
        }

        if(num == 3)
        {
            this.transform.DOMoveX(L, 30).SetEase(Ease.Linear);
        }

        if(num == 4)
        {
            this.transform.DORotate(R, 30).SetLoops(-1, LoopType.Yoyo);
        }
        
    }
}
