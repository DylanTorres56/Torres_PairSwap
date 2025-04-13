using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{    
    public void ToMenu() 
    {
        SceneManager.LoadScene(0);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ContinueFromLastLevel() 
    {
        SceneManager.LoadScene(1); // TO DO: REPLACE WITH SAVE SYSTEM (PlayerPrefs)!
    }

}
