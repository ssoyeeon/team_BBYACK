using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ExPlay : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.PlaySound("BackGround");
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
