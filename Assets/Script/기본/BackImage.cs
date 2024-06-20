using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackImage : MonoBehaviour
{
    public GameObject Back;

    void Update()
    {
        gameObject.transform.position += new Vector3 ( 0f, 0.03f, 0f );
    }
}
