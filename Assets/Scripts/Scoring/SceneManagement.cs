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

    public void ToLevel()
    {
        SceneManager.LoadScene(1);
    }

}
