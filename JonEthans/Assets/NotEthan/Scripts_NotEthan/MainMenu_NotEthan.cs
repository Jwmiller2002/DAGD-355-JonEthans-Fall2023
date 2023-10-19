using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_NotEthan : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }

    public void Hammer()
    {
        SceneManager.LoadScene(1);
    }
    public void Bat()
    {
        SceneManager.LoadScene(4);
    }
    public void Knife()
    {
        SceneManager.LoadScene(2);
    }
    public void QuitGame()
    { 
    Application.Quit();
    }

    public void Controls()
    { 
    
    }
}
