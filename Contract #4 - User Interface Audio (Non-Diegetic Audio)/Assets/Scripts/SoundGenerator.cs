using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoundGenerator : MonoBehaviour
{
    public TMP_InputField frequency;
    public AudioClip soundEffect;

    public AudioSource source;
    private int frequencyValue;

    private void Start()
    {
        CreateToneAudioClip(2000);
        source = GetComponent<AudioSource>();
        soundEffect = Resources.Load<AudioClip>("audioClip");
        source.PlayOneShot(soundEffect);
    }
    private AudioClip CreateToneAudioClip(int frequency)
    {
        int sampleDurationSecs = 5;
        int sampleRate = 44100;
        int sampleLength = sampleRate * sampleDurationSecs;
        float maxValue = 1f / 4f;

        var audioClip = AudioClip.Create("audioClip", sampleLength, 1, sampleRate, false);

        float[] samples = new float[sampleLength];
        for (var i = 0; i < sampleLength; i++)
        {
            float s = Mathf.Sin(2.0f * Mathf.PI * frequency * ((float)i / (float)sampleRate));
            float v = s * maxValue;
            samples[i] = v;
        }
        audioClip.SetData(samples, 0);
        return audioClip;
    }

    void CheckForFrequency()
    {
        frequencyValue = int.Parse(frequency.text);
    }


    void Update()
    {
        //if (frequency.text != "")
        {
            //CheckForFrequency();
            //CreateToneAudioClip(frequencyValue);
        }
    }
}
