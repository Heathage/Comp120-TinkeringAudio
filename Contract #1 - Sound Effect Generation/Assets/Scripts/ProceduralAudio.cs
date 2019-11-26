using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Note to reviewer. I found this code and tried to implement it last night, I am still trying to decipher it.

[RequireComponent(typeof(AudioLowPassFilter))]
public class ProceduralAudio : MonoBehaviour
{
    private float sampling_frequency = 48000;

    [Range(0f, 1f)]
    public float noiseRatio = 0.5f;

    [Range(-1f, 1f)]
    public float offset;

    public float cutoffOn = 800;
    public float cutoffOff = 100;

    public bool cutOff;


    public float frequency = 440f;
    public float gain = 0.05f;

    private float increment;
    private float phase;

    System.Random rand = new System.Random();
    AudioLowPassFilter lowPassFilter;

    void Awake()
    {
        sampling_frequency = AudioSettings.outputSampleRate;

        lowPassFilter = GetComponent<AudioLowPassFilter>();
        Update();
    }

    private void OnAudioFilterRead(float[] data, int channels)
    {
        float tonalPart = 0;
        float noisePart = 0;

        increment = frequency * 2f * Mathf.PI / sampling_frequency;

        for (int i = 0; i < data.Length; i++)
        {
            noisePart = noiseRatio * (float)(rand.NextDouble() * 2.0 - 1.0 + offset);

            phase = phase + increment;

            if (phase > 2 * Mathf.PI) phase = 0;

            tonalPart = (1f - noiseRatio) * (float)(gain * Mathf.Sin(phase));

            data[i] = noisePart + tonalPart;

            if (channels == 2)
            {
                data[i + 1] = data[i];
                i++;
            }

        }

    }

    void Update()
    {
        lowPassFilter.cutoffFrequency = cutOff ? cutoffOn : cutoffOff;
    }

}
