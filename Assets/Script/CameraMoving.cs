using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
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
            transform.position = new Vector3(target.position.x, target.position.y + 3, transform.position.z);
            
        }
         
        //if(target.transform.position.y>0)
        //{
        //    Camera.main.transform.position = StopCoroutine;
        //}
    }
}

//원하는 것 = 카메라가 플레이어의 최대 높이일 때 멈췄으면 좋겠음... --> target의 최대 y 좌표만 못 가져오낭..?
//생각한 것 = target이 살아있을 때 계속 올라갈테니 if y>0 일때 최대 높이에서 카메라 포지션을 멈춤... 인데 가능한가?...
//카메라가 밑으로 못 떨어지게 하면 돼 --> target이 null 상태일 때 camera position < 0 ? 
