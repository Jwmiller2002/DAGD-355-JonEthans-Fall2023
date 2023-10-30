using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameReset : MonoBehaviour
{
    public void ResetTheGame()
    {
        SceneManager.LoadScene(0);
        Debug.Log("click");
    }
}
