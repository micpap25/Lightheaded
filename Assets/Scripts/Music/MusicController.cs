using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource aus;
    private AudioClip currentClip;

    private void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        aus = GetComponent<AudioSource>();
    }

    public void PlayMusic(AudioClip mus)
    {
        if (!aus.clip.Equals(mus))
        {
            aus.Stop();
            aus.clip = mus;
            aus.Play();
        }
    }
}
