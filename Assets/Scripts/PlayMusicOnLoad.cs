using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicOnLoad : MonoBehaviour
{
    public AudioClip clip;
    // Start is called before the first frame update
    void Awake()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicController>().PlayMusic(clip);
    }
}
