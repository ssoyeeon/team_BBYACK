using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Rigidbody _Rigidbody;
    public int Force = 100;
    public int Force1 = 20;
    public float moveSpeed = 5f;
    public float Force2 = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * Force);
            GetComponent<Rigidbody>().AddForce(Vector3.left * Force2);
        }

        if (Input.GetMouseButtonDown(1))
        {
            _Rigidbody.AddForce(transform.up * Force);
            _Rigidbody.AddForce(transform.right * Force1);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            gameObject.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
            Debug.Log(collision.gameObject.name);
        }
    }
}
