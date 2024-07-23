using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG;
using DG.Tweening;

public class BackGroundLR : MonoBehaviour
{
    public int num;
    public enum State
    {
        Default,
        Star,
        Up,
        Right,
        Left
    }
    public State state = State.Default;
    public int L = 10;
    public int U = 1;
    public Vector3 R;

    void Start()
    {
        if (state == State.Left)
        {
            this.transform.DOMoveX(L, 30).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
        }
        else if(state == State.Up)
        {
            this.transform.DOMoveY(U,17).SetEase(Ease.Linear);
        }
        else if (state == State.Right)
        {
            this.transform.DOMoveX(L, 30).SetEase(Ease.Linear);
        }
        else if(state == State.Star)
        {
            this.transform.DORotate(R, 30).SetLoops(-1, LoopType.Yoyo);
        }
        
    }
}
