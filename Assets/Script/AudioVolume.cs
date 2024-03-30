using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioVolume : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider bgmSlider;

    void Start()
    {
        bgmSlider.onValueChanged.AddListener(SetAudioMixer);
    }

    void SetAudioMixer(float value)
    {
        value /= 5;
        var volume = Mathf.Clamp(Mathf.Log10(value) * 20f, -80f, 0f);
        audioMixer.SetFloat("BGM", volume);
        audioMixer.SetFloat("SE", volume);
    }
}
