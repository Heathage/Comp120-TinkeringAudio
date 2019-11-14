using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTone : MonoBehaviour
{
    public AudioClip soundEffect;
    private AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
        soundEffect = Resources.Load<AudioClip>("tone");
    }
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            source.PlayOneShot(soundEffect);
        }
    }
}
