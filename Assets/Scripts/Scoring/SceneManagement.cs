using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    // public static SceneManagement Instance; // This scene management script is a singleton, so only 1 instance of it exists in game at all times.

    // Start is called before the first frame update
    void Start()
    {
        /* if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else 
        {
            DontDestroyOnLoad(gameObject); // Let this game object persist into other screens.
            Instance = this; // Set global reference
        } */
    }

    public void ToMenu() 
    {
        SceneManager.LoadScene(0);
    }

    public void ToLevel()
    {
        SceneManager.LoadScene(1);
    }

    /* public void ToGameOver() 
    {
        SceneManager.LoadScene(2);
    } */
}
