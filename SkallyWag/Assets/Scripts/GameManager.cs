using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] P_Controls playerScript;
    [SerializeField] E_Bhvr enemyScript;

    public bool isAlive = true;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {

    }

    private void Update()
    {
        if (playerScript.isAlive == false)
        {
            Debug.Log("Dead");
        }

        if (playerScript.pHealth == 0)
        {
            isAlive = false;
        }
    }

    //PlayBtn to load the gameScene
    public void PlayBtn()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
}
