using UnityEngine;
using UnityEngine.UI;
using System;

public class SoundGenerator : MonoBehaviour
{
    public Slider frequencySlider;
    public Slider volumeSlider;
    public Slider durationSlider;
    public AudioClip soundEffect;
    public Text frequencyText;
    public Text durationText;
    public Text volumeText;
    public InputField saveNameInput;

    public AudioSource source;

    private int frequencyValue;
    private int durationValue;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.volume = 0f;
        durationValue = 1;
    }

    private void Update()
    {
        FrequencyTextUpdate();
        FrequencyValueUpdate();
        DurationTextUpdate();
        VolumeTextUpdate();
    }

    private AudioClip CreateToneAudioClip(int frequency, int duration)
    {
        int sampleDurationSecs = duration;
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

    public void ChangeVolume()
    {
        source.volume = volumeSlider.value;
    }

    public void VolumeTextUpdate()
    {
        volumeText.text = source.volume.ToString("F2");
    }
    public void ChangeDuration()
    {
        durationValue = Mathf.RoundToInt(durationSlider.value);
    }

    public void DurationTextUpdate()
    {
        durationText.text = durationValue.ToString() + " seconds";
    }

    public void CreateSound()
    {
        soundEffect = CreateToneAudioClip(frequencyValue, durationValue);
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