using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class SceneManagement : MonoBehaviour
{    
    public void ToMenu() 
    {
        SceneManager.LoadScene(0);
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("nSI", 1);
        SceneManager.LoadScene(1);
    }

    public void ContinueFromLastLevel() 
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("nSI"));
    }

    public void QuitGame() 
    {
        Application.Quit();
    }

}
