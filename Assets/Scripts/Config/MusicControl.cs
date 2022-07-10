using UnityEngine;

public class MusicControl : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isMusicMuted = false;

    [SerializeField, Range(0, 1)]
    private float musicVolume = 0.5f;
    [SerializeField]
    private GameObject muteGameObject, unmuteGameObject;

    private void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();
    }

    private void Update()
    {
        if (!isMusicMuted)
            audioSource.volume = musicVolume;
    }

    public void MuteMusicButtonEvent()
    {
        isMusicMuted = true;
        audioSource.volume = 0f;

        muteGameObject.SetActive(true);
        unmuteGameObject.SetActive(false);
    }

    public void UnmuteMusic()
    {
        isMusicMuted = false;
        audioSource.volume = musicVolume;

        unmuteGameObject.SetActive(true);
        muteGameObject.SetActive(false);
    }
}
