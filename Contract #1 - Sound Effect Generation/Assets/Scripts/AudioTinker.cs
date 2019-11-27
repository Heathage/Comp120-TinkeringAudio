using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif


public class AudioTinker : MonoBehaviour {
    private AudioSource audioSource;
    private AudioClip outAudioClip;

    //This is so that I can create a random frequency to be passed so that the same tone is not always played.
    int ranFreq;
    //This allows me to create a value that I can use to increase the frequency of a tone when a particular action is completed. 
    int totalPickups = 0;

    /// <summary>
    /// Accesses the audio source component on the Game Object in unity. Could not play tones without it. 
    /// </summary>
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    /// <summary>
    /// Plays the tone that is generated, method allows me to easily call the function.
    /// </summary>
    public void PlayOutAudio() 
    {
        audioSource.PlayOneShot(outAudioClip);
    }
        
    /// <summary>
    /// Takes the parameters passed through from other functions and uses them to create tones. They vary based on the values passed.
    /// This is needed to create the tones that the player hears. 
    /// </summary>
    /// <param name="frequency"></param>
    /// <param name="duration"></param>
    /// <param name="totalPickups"></param>
    /// <returns></returns>
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

    /// <summary>
    /// When a player picks up a pink cube, plays a tone with these values to signify successful collection.
    /// </summary>
    public void PickUpSound()
    {
        //The frequency of the tone gradually increases as more pink cubes are picked up. 
        totalPickups = totalPickups + 25;
        Debug.Log("Picked up");
        Debug.Log(ranFreq);
        outAudioClip = CreateToneAudioClip(750, 0.25f, totalPickups);
        PlayOutAudio();
    }

    /// <summary>
    /// When a player picks up the red cube, plays a tone with these values to signify the trap being sprung. 
    /// </summary>
    public void TrapSound()
    {
        Debug.Log("Trapped");
        outAudioClip = CreateToneAudioClip(500, 1.0f, 0);
        PlayOutAudio();
    }

    /// <summary>
    /// When the trap has closed, plays a tone with these values to signify the blocks hitting the ground. 
    /// The value for the frequency is randomised between two pre-set values to create a layered sound. 
    /// </summary>
    public void ObstacleHitGroundSound()
    {
        ranFreq = Random.Range(350, 450);
        Debug.Log("Obstacle!");
        Debug.Log(ranFreq);
        outAudioClip = CreateToneAudioClip(ranFreq, 0.6f, 0);
        PlayOutAudio();
    }

    /// <summary>
    /// When the player picks up the gold cube, plays a tone with these values to signify victory. 
    /// </summary>
    public void Goal()
    {
        //timer between each PlayOutAudio??
        outAudioClip = CreateToneAudioClip(1000, 1.0f, 0);
        PlayOutAudio();
    }
}
