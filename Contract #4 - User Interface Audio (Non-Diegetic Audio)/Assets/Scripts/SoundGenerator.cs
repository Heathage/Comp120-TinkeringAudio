using UnityEngine;
using UnityEngine.UI;
using System;

public class SoundGenerator : MonoBehaviour
{
    /// <summary>
    /// Each changable variable of the sound has it's own Slider, Text and Value which is used on the UI creation page.
    /// All of the variables are public variables as this makes it much easier for designers to be able to use the program as it is simply drag and drop.
    /// Similarly, the implementation of sliders are in the project to enable designers within the team to be able to edit sounds so that they are suitable
    /// for the project. An audio source is also declared here as this will be the main variable to be used during sound creation.
    /// </summary>

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

    /// <summary>
    /// Within the start function, multiple operations are performed. Firstly, the audio source is stored within the source variable. This variable can be used to directly edit the
    /// audio source. This is needed to perform volume changes etcetera. Other values set within the start function are done to set default values for the different editable factors of the sound.
    /// This is done, mostly, to ensure that the UI looks presentable and does not have strange values. 
    /// </summary>

    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.volume = 0f;
        durationValue = 1.00f;
        sampleValue = 44100;
        sampleText.text = "1000";
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
        VolumeTextUpdate();
    }

    public void VolumeTextUpdate()
    {
        volumeText.text = source.volume.ToString("F2");
    }

    public void ChangeSampleRate()
    {
        sampleValue = Mathf.RoundToInt(sampleSlider.value);
        SampleRateTextUpdate();
    }

    public void SampleRateTextUpdate()
    {
        sampleText.text = sampleSlider.value.ToString();
    }

    public void ChangeDuration()
    {
        durationValue = (durationSlider.value);
        DurationTextUpdate();
    }

    public void DurationTextUpdate()
    {
        durationText.text = durationValue.ToString("F2") + " seconds";
    }


    public void FrequencyValueUpdate()
    {
        frequencyValue = Mathf.RoundToInt(frequencySlider.value);
        FrequencyTextUpdate();
    }

    public void FrequencyTextUpdate()
    {
        frequencyText.text = frequencyValue.ToString() + "Hz";
    }


    public void CreateSound()
    {
        soundEffect = CreateToneAudioClip(frequencyValue, durationValue, sampleValue);
        source.PlayOneShot(soundEffect);
    }

    public void SaveToWav()
    {
        SavWav.Save(saveNameInput.text, soundEffect);
    }
}