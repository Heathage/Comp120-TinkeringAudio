using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToneGenerator : MonoBehaviour
{
    public InputField frequency;
    private int frequencyValue;

    private AudioClip CreateToneAudioClip(int frequency)
    {
        int sampleDurationSecs = 5;
        int sampleRate = 44100;
        int sampleLength = sampleRate * sampleDurationSecs;
        float maxValue = 1f / 4f;

        var audioClip = AudioClip.Create("tone", sampleLength, 1, sampleRate, false);

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
        if (frequency.text != "")
        {
            CheckForFrequency();
            CreateToneAudioClip(frequencyValue);
        }
    }
}
