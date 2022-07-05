using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instace { get; private set; }
    private AudioSource source;
    [SerializeField] private AudioSource backgroundMusicSource;

    private void Awake()
    {
        instace = this;
        source = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip sound)
    {
        source.PlayOneShot(sound);
    }

    public void ChangeBackgroundMusic(AudioClip sound)
    {
        backgroundMusicSource.clip = sound;
        backgroundMusicSource.Play();
    }
    
}
