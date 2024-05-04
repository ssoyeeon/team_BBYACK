using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearLine : MonoBehaviour
{
    [SerializeField] private GameObject Muge;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            if (GameObject.Instantiate<GameObject>(Muge) == null)
            {
                SceneManager.LoadScene("C.StartScene");
            }

            else if (GameObject.Instantiate<GameObject>(Muge) != null)
            {
                SceneManager.LoadScene("C.GameOver");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
