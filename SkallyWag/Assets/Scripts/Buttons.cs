using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    public GameObject GameMenu;
    public GameObject PauseMenu;

    public void pauseMenu()
    {
        Time.timeScale = 0;
        GameMenu.SetActive(false);
        PauseMenu.SetActive(true);
    } 

    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        GameMenu.SetActive(true);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }
}
