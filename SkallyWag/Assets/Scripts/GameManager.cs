using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] P_Controls playerScript;
    [SerializeField] E_Bhvr enemyScript;
    public int playerHealth;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {

    }

    private void Update()
    {


    }

    //PlayBtn to load the gameScene
    public void PlayBtn()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }

    //Killing the player
    public void Death()
    {
        SceneManager.LoadScene(sceneBuildIndex: 2);
    }

    //Back to main menu
    public void MainMenu()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }
}
