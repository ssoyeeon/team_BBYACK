using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraMoving : MonoBehaviour
{
    public Transform target; // 카메라가 따라다닐 대상 (플레이어)

    void Update()
    {
        if (target != null)
        {
            // 플레이어의 현재 위치를 가져와 카메라의 위치로 설정합니다.
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        }
    }
}
