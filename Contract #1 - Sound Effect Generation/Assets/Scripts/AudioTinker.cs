using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif


public class AudioTinker : MonoBehaviour {
    private AudioSource audioSource;
    private AudioClip outAudioClip;

    int ranFreq;
    int totalPickups = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    //Used to play the tone generated
    
    public void PlayOutAudio() {
        audioSource.PlayOneShot(outAudioClip);    
    }
        
    // Generates the tone with reference to the frequency passed
    
    private AudioClip CreateToneAudioClip(int frequency, float duration, int totalPickups) 
    {
        float sampleDurationSecs = duration;
        int sampleRate = 44100;
        int sampleLength = Mathf.FloorToInt(sampleRate * sampleDurationSecs);
        float maxValue = 1f / 4f;
        
        var audioClip = AudioClip.Create("tone", sampleLength, 1, sampleRate, false);
        
        float[] samples = new float[sampleLength];
        for (var i = 0; i < sampleLength; i++) 
        {
            float s = Mathf.Sin(2.0f * Mathf.PI * (frequency + totalPickups) * ((float) i / (float) sampleRate));
            float v = s * maxValue;
            samples[i] = v;
        }

        audioClip.SetData(samples, 0);
        return audioClip;
    }

    //Generates a tone for picking up objects and plays it.

    public void PickUpSound()
    {
        totalPickups = totalPickups + 25;
        //ranFreq = Random.Range(750, 850);
        Debug.Log("Picked up");
        Debug.Log(ranFreq);
        outAudioClip = CreateToneAudioClip(750, 0.25f, totalPickups);
        PlayOutAudio();
    }

    //Generates a tone for when the player activates the trap and plays it.

    public void TrapSound()
    {
        Debug.Log("Trapped");
        outAudioClip = CreateToneAudioClip(500, 1.0f, 0);
        PlayOutAudio();
    }

    //Generates a tone for when the trap obstacles hit the ground and plays it.

    public void ObstacleHitGroundSound()
    {
        ranFreq = Random.Range(350, 450);
        Debug.Log("Obstacle!");
        Debug.Log(ranFreq);
        outAudioClip = CreateToneAudioClip(ranFreq, 0.6f, 0);
        PlayOutAudio();
    }

    public void Goal()
    {
        outAudioClip = CreateToneAudioClip(1000, 1.0f, 0);
        PlayOutAudio();
    }
}
