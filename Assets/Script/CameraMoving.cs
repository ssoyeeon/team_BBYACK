using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraMoving : MonoBehaviour
{
    public Transform target; // ī�޶� ����ٴ� ��� (�÷��̾�)

    void Update()
    {
        if (target != null)
        {
            // �÷��̾��� ���� ��ġ�� ������ ī�޶��� ��ġ�� �����մϴ�.
            transform.position = new Vector3(target.position.x, target.position.y + 3, transform.position.z);
            
        }
         
        //if(target.transform.position.y>0)
        //{
        //    Camera.main.transform.position = StopCoroutine;
        //}
    }
}

//���ϴ� �� = ī�޶� �÷��̾��� �ִ� ������ �� �������� ������... --> target�� �ִ� y ��ǥ�� �� ��������..?
//������ �� = target�� ������� �� ��� �ö��״� if y>0 �϶� �ִ� ���̿��� ī�޶� �������� ����... �ε� �����Ѱ�?...
//ī�޶� ������ �� �������� �ϸ� �� --> target�� null ������ �� camera position < 0 ? 
