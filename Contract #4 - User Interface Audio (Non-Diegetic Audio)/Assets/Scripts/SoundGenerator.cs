using UnityEngine;
using UnityEngine.UI;

public class SoundGenerator : MonoBehaviour
{
    public Slider frequencySlider;
    public Slider volumeSlider;
    public Slider durationSlider;
    public AudioClip soundEffect;

    public AudioSource source;

    private int frequencyValue;
    private int durationValue;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.volume = 0f;
        volumeSlider.value = 0f;
    }

    private void Update()
    {
        frequencyValue = Mathf.RoundToInt(frequencySlider.value);
    }

    private AudioClip CreateToneAudioClip(int frequency, int duration)
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

    public void ChangeVolume()
    {
        source.volume = volumeSlider.value;
    }

    public void CreateSound()
    {
        soundEffect = CreateToneAudioClip(frequencyValue, durationValue);
        source.PlayOneShot(soundEffect);
    }

    public void ChangeDuration()
    {
        durationValue = Mathf.RoundToInt(durationSlider.value);
    }
}