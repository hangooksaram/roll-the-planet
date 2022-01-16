using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// scene import 하려면 필요
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public Vector3 jumpPower = new Vector3(0, 30, 0);
    public bool isJump;
    public int itemCount = 0;
    public GameManagerLogic manager;
    AudioSource audio;

    Rigidbody rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        isJump = false;
    }

    void Update()
    {
        Jump();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 movePosition = new Vector3(horizontal, 0, vertical);

        rigid.AddForce(movePosition, ForceMode.Impulse);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            rigid.AddForce(jumpPower, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag== "Map")
        {
            isJump = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            itemCount++;
            audio.Play();
            other.gameObject.SetActive(false);
            manager.GetPlayerItemCount(itemCount);
        }
        else if (other.tag == "Finish")
        {
            if (manager.totalItemCount == itemCount)
            {
                SceneManager.LoadScene(manager.stage+1);
            }
            else
            {
                SceneManager.LoadScene(manager.stage);
            }
        }
    }
}
