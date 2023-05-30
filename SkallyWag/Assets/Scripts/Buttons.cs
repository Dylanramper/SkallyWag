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

    public bool toggleCon;

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
    
    public void DragCon()
    {
        if (toggleCon == false)
        {
            Drag.GetComponent<P_Drag>().enabled = true;
            Joystk.GetComponent<P_JoyStk>().enabled = false;
        }
        else if(toggleCon == true){
            Drag.GetComponent<P_Drag>().enabled = false;
            Joystk.GetComponent<P_JoyStk>().enabled = true;
        }
    }
}
