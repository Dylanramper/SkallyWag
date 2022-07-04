using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    public GameObject GameMenu;
    public GameObject PauseMenu;

    //Pause button
    public void pauseMenu()
    {
        Time.timeScale = 0;
        GameMenu.SetActive(false);
        PauseMenu.SetActive(true);
    } 

    //Resume button
    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        GameMenu.SetActive(true);
        Time.timeScale = 1;
    }

    //Quit button
    public void Quit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }
}
