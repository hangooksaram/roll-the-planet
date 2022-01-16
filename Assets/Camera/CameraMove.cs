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
    // ���� UI or ī�޶� update �� ���
    void LateUpdate()
    {
        transform.position = playerTransForm.position + Offset;
    }
}
