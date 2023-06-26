using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject GameMenu;
    public GameObject PauseMenu;
    public GameObject SettingsMenu;

    public GameObject Joystk;
    public GameObject Drag;

    public GameObject joyone, joytwo;

    public int controls;

    public bool paused = false;

    private void Start()
    {

    }

    //Pause button
    public void pauseMenu()
    {
        Time.timeScale = 0;
        GameMenu.SetActive(false);
        PauseMenu.SetActive(true);
        paused = true;
    }

    //Resume button
    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        GameMenu.SetActive(true);
        Time.timeScale = 1;
        paused = false;
    }

    //Quit button
    public void Quit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneBuildIndex: 0);
        paused = false;
    }

    //Settings button
    public void Settings()
    {
        PauseMenu.SetActive(false);
        SettingsMenu.SetActive(true);
    }

    //Back from settings menu
    public void Backfromsettings()
    {
        SettingsMenu.SetActive(false);
        PauseMenu.SetActive(true);
    }

    public void DragCon(bool toggleCon)
    {
        if (toggleCon)
        {
            Drag.GetComponent<P_Drag>().enabled = false;
            Joystk.GetComponent<P_JoyStk>().enabled = true;
            joyone.SetActive(true);
            joytwo.SetActive(true);
            controls = 0;
            Debug.Log(controls);
        }
        else if (!toggleCon){
            Drag.GetComponent<P_Drag>().enabled = true;
            Joystk.GetComponent<P_JoyStk>().enabled = false;
            joyone.SetActive(false);
            joytwo.SetActive(false);
            controls = 1;
            Debug.Log(controls);
        }
    }
}
