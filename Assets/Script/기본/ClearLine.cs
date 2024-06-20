using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ClearLine : MonoBehaviour
{
    public GameObject[] mergee;

    public void OnCollisionEnter(Collision collision)
    {
        Mushroom mushroomComponent = collision.gameObject.GetComponentInParent<Mushroom>();

        if (collision.collider.tag == "Player" && mushroomComponent == null)
        {
            Debug.Log("Ω««‡«‡");
            SceneManager.LoadScene("C.Clear");
        }
    }
}
