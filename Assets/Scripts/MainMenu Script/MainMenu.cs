using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GameObject NewGame_Button;
    public GameObject LevelSelect_Button;

    //public Animator ani;

    //public void Start()
    //{
    //    ani.enabled = false;
    //}

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitQame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void EnableUIComponents()
    {
        NewGame_Button.SetActive(true);
        LevelSelect_Button.SetActive(true);
    }

    //public void EnableAnimation()
    //{
    //    ani.enabled = true;
    //}
}
