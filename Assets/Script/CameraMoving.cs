using System.Collections;
using System.Collections.Generic;
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
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        }
    }
}
