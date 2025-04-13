using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // Singleton pattern that will preserve audio levels between scenes!

    [Header("Audio Sources: ")]
    public AudioSource musicSource;
    public AudioSource effectSource;

    [Header("Audio Clips: ")]
    public AudioClip oST;
    public AudioClip[] gameplaySFX = new AudioClip[10];
    
    // Awake is called on the first active frame.
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayOST();
    }

    public void PlayOST() 
    {
        musicSource.clip = oST;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clipToPlay) 
    {
        effectSource.PlayOneShot(clipToPlay);
    }
}
