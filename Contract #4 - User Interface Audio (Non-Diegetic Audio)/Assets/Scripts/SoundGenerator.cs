using UnityEngine;
using UnityEngine.UI;
using System;

public class SoundGenerator : MonoBehaviour
{
    public Slider frequencySlider;
    public Slider volumeSlider;
    public Slider durationSlider;
    public Slider sampleSlider;
    public AudioClip soundEffect;
    public Text frequencyText;
    public Text durationText;
    public Text volumeText;
    public Text sampleText;
    public InputField saveNameInput;

    public AudioSource source;

    private int frequencyValue;
    private int sampleValue;
    private float durationValue;


    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.volume = 0f;
        durationValue = 1.00f;
        sampleValue = 44100;
        sampleText.text = "1000";
    }

    private void Update()
    {
        FrequencyTextUpdate();
        FrequencyValueUpdate();
        DurationTextUpdate();
        VolumeTextUpdate();
        SampleRateTextUpdate();
    }

    private AudioClip CreateToneAudioClip(int frequency, float duration, int sample)
    {
        float sampleDurationSecs = duration;
        int sampleRate = sample;
        int sampleLength = Mathf.FloorToInt(sampleRate * sampleDurationSecs);
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

    public void ChangeVolume()
    {
        source.volume = volumeSlider.value;
    }

    public void VolumeTextUpdate()
    {
        volumeText.text = source.volume.ToString("F2");
    }

    public void ChangeSampleRate()
    {
        sampleValue = Mathf.RoundToInt(sampleSlider.value);
    }

    public void SampleRateTextUpdate()
    {
        sampleText.text = sampleSlider.value.ToString();
    }

    public void ChangeDuration()
    {
        durationValue = (durationSlider.value);
    }

    public void DurationTextUpdate()
    {
        durationText.text = durationValue.ToString("F2") + " seconds";
    }

    public void CreateSound()
    {
        soundEffect = CreateToneAudioClip(frequencyValue, durationValue, sampleValue);
        source.PlayOneShot(soundEffect);
    }

    public void FrequencyTextUpdate()
    {
        frequencyText.text = frequencyValue.ToString() + "Hz";
    }

    public void FrequencyValueUpdate()
    {
        frequencyValue = Mathf.RoundToInt(frequencySlider.value);
    }

    public void SaveToWav()
    {
        SavWav.Save(saveNameInput.text, soundEffect);
    }
}