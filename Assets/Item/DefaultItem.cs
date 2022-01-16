using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultItem : MonoBehaviour
{
    public float rotateSpeed;
    private void Awake()
    {
        rotateSpeed = 60f;
    }
    private void Update()
    {

        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
    }

}
