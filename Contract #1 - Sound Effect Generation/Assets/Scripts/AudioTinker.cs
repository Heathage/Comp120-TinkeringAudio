using System.Collections;
using System.Collections.Generic;
//using NaughtyAttributes;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif


public class AudioTinker : MonoBehaviour {
    private AudioSource audioSource;
    private AudioClip outAudioClip;
    bool dropped = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    //Used to play the tone generated
    
    public void PlayOutAudio() {
        audioSource.PlayOneShot(outAudioClip);    
    }

    //public void StopAudio() {
        //audioSource.Stop();
    //}
        
    // Generates the tone with reference to the frequency passed
    
    private AudioClip CreateToneAudioClip(int frequency) {
        int sampleDurationSecs = 1;
        int sampleRate = 44100;
        int sampleLength = sampleRate * sampleDurationSecs;
        float maxValue = 1f / 4f;
        
        var audioClip = AudioClip.Create("tone", sampleLength, 1, sampleRate, false);
        
        float[] samples = new float[sampleLength];
        for (var i = 0; i < sampleLength; i++) {
            float s = Mathf.Sin(2.0f * Mathf.PI * frequency * ((float) i / (float) sampleRate));
            float v = s * maxValue;
            samples[i] = v;
        }

        audioClip.SetData(samples, 0);
        return audioClip;
    }

    //Generates a tone for picking up objects and plays it.

    public void PickUpSound()
    {
        Debug.Log("Picked up");
        outAudioClip = CreateToneAudioClip(1000);
        PlayOutAudio();
    }

    //Generates a tone for when the player activates the trap and plays it.

    public void TrapSound()
    {
        Debug.Log("Trapped");
        outAudioClip = CreateToneAudioClip(500);
        PlayOutAudio();
    }

    //Generates a tone for when the trap obstacles hit the ground and plays it.

    public void ObstacleHitGroundSound()
    {
        if (!dropped)
        {
            dropped = true;
            Debug.Log("Obstacle!");
            outAudioClip = CreateToneAudioClip(300);
            PlayOutAudio();
        }

        //Prevents the tone playing again when the trap has already dropped.
        else
        {
            Debug.Log("Dropped");
        }
    }


#if UNITY_EDITOR
    //[Button("Save Wav file")]
    private void SaveWavFile() {
        string path = EditorUtility.SaveFilePanel("Where do you want the wav file to go?", "", "", "wav");
        var audioClip = CreateToneAudioClip(1500);
        SaveWavUtil.Save(path, audioClip);
    }
#endif
}