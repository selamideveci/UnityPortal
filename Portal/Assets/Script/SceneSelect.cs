using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelect : MonoBehaviour
{
    public void selectScene()
    {
        switch (this.gameObject.name){
        case "Level1Button":
            SceneManager.LoadScene("Level1");
            break;
        case "Level2Button":
            SceneManager.LoadScene("Level2");
            break;
        case "Level3Button":
            SceneManager.LoadScene("level3");
            break;
        case "Level4Button":
            SceneManager.LoadScene("level4");
            break;


        }
    }
}
