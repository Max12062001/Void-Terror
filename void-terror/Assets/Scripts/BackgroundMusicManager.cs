using System.Collections;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    public AudioClip backgroundMusic1;
    public AudioClip chaseMusic;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("AudioSource component missing from this game object. Please add an AudioSource component.");
            return;
        }

        if (backgroundMusic1 == null || chaseMusic == null)
        {
            Debug.LogError("Please assign the audio clips for the background music and chase music.");
            return;
        }

        PlayBackgroundMusic();
    }

    public void PlayBackgroundMusic()
    {
        audioSource.clip = backgroundMusic1;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayChaseMusic()
    {
        audioSource.clip = chaseMusic;
        audioSource.loop = true;
        audioSource.Play();
    }
}
