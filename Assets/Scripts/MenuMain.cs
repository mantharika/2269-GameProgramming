using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMain : MonoBehaviour
{
   public void StartGame(int buildindex)
    {
        SceneManager.LoadScene(buildindex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
