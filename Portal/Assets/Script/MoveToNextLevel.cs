using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLevel : MonoBehaviour
{
    public int nextSeceneLoad;
    // Start is called before the first frame update
    void Start()
    {
        nextSeceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag=="Player")
        {
            if (SceneManager.GetActiveScene().buildIndex==6)
            {
                              Debug.Log("You Win");
            }
            else
            {
                SceneManager.LoadScene(nextSeceneLoad);

                if (nextSeceneLoad>PlayerPrefs.GetInt("levelAt"))
                {
                    PlayerPrefs.SetInt("levelAt",nextSeceneLoad);
                }
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
