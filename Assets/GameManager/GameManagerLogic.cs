using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManagerLogic : MonoBehaviour
{
    public int totalItemCount;
    public int stage;
    public Text playerItemCount;
    public Text stageItemCount;
    
    public void Awake()
    {
        stageItemCount.text = "/ " + totalItemCount.ToString();
    }

    public void GetPlayerItemCount (int count)
    {
        playerItemCount.text = count.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            SceneManager.LoadScene(stage);
        }
    }

}
