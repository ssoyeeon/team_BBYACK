using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public float duration;
    public SpriteRenderer spr;

    void Start()
    { 
            spr = GetComponent<SpriteRenderer>();
            spr.DOFade(0f, duration).SetLoops(-1, LoopType.Yoyo);           //DOFade∏¶ ≈Î«ÿ ∞¯¿ª ±Ù∫˝¿”
    }
}
