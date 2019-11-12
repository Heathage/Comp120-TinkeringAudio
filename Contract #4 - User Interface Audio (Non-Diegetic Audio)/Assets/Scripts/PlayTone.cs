using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTone : MonoBehaviour
{
    public AudioClip musicTrack;
    private AudioSource source;
    private bool musicPlaying;
    void Start()
    {
        source = GetComponent<AudioSource>();
        musicTrack = Resources.Load<AudioClip>("music");
        musicPlaying = false;
    }
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (!musicPlaying)
            {
                source.Play();
                musicPlaying = true;
            }
            else
            {
                source.Stop();
                musicPlaying = false;
            }
        }
    }
}
