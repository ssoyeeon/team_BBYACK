using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Rigidbody _Rigidbody;
    public int Force = 100;
    public int Force1 = 20;
    public float moveSpeed = 5f;
    public float moveSpeed1 = 5f;

    public Vector3 minPosition = new Vector3(-15f, -10f, -15f);
    public Vector3 maxPosition = new Vector3(15f, 100f, 15f);
    public Vector3 originalPosition = new Vector3(0f,0f,0f);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * Force);
            GetComponent<Rigidbody>().AddForce(Vector3.left * Force1);

            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0;
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
            targetPosition.z = Mathf.Clamp(targetPosition.z, minPosition.z, maxPosition.z);

            transform.position = targetPosition;
        }

        if (Input.GetMouseButtonDown(1))
        {
            _Rigidbody.AddForce(transform.up * Force);
            _Rigidbody.AddForce(transform.right * Force1);

            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0;
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
            targetPosition.z = Mathf.Clamp(targetPosition.z, minPosition.z, maxPosition.z);

            transform.position = targetPosition;
            
        }

        Vector3 clasmpedPosition = transform.position;
        clasmpedPosition.x = Mathf.Clamp(clasmpedPosition.x, minPosition.x, maxPosition.x);
        clasmpedPosition.y = Mathf.Clamp(clasmpedPosition.y, minPosition.y, maxPosition.y);
        clasmpedPosition.z = Mathf.Clamp(clasmpedPosition.z, minPosition.z, maxPosition.z);

        if (transform.position != clasmpedPosition)
        {
            transform.position = originalPosition;
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
