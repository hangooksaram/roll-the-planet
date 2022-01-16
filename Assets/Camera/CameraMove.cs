using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Transform playerTransForm;
    Vector3 Offset;
    private void Awake()
    {
        playerTransForm = GameObject.Find("Player").transform;
        Offset = transform.position - playerTransForm.position;
    }
    // 보통 UI or 카메라 update 에 사용
    void LateUpdate()
    {
        transform.position = playerTransForm.position + Offset;
    }
}
