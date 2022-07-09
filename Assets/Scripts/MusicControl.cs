using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    AudioSource audioSource;

    public GameObject MuteButton;
    public GameObject UnMuteButton;

    private void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();
    }

    public void MuteMusic()
    {
        audioSource.volume = 0f;
        MuteButton.SetActive(true);
        UnMuteButton.SetActive(false);
    }

    public void UnMuteMusic()
    {
        audioSource.volume = 0.2f;
        UnMuteButton.SetActive(true);
        MuteButton.SetActive(false);
    }
}
