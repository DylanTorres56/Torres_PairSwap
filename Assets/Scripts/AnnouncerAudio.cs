using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnouncerAudio : MonoBehaviour
{
    [SerializeField] int incidentalAudioIndex;

    // Awake is called on the first active frame update
    void Awake()
    {
        StartCoroutine(PlayAnnouncerAudio());
    }

    IEnumerator PlayAnnouncerAudio() 
    {
        yield return new WaitForSeconds(0.01f);
        AudioManager.instance.PlaySFX(AudioManager.instance.gameplaySFX[incidentalAudioIndex]);
    }

}
