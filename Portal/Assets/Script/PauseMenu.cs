using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused =false;
    public GameObject PauseMenuUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive((false));
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    void Pause()
    {
              PauseMenuUI.SetActive(true);
              Time.timeScale = 0f;
              GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
         SceneManager.LoadScene(("Giriş"));
    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }

}
