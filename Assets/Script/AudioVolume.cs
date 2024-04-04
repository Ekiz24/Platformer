using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioVolume : MonoBehaviour
{
    //[SerializeField] AudioMixer audioMixer;
    //[SerializeField] Slider bgmSlider;
    GameObject bgm;

    void Start()
    {
        //bgmSlider.onValueChanged.AddListener(SetAudioMixer);
        bgm = GameObject.Find("BGM");
    }
    /*
    void SetAudioMixer(float value)
    {
        value /= 5;
        var volume = Mathf.Clamp(Mathf.Log10(value) * 20f, -80f, 0f);
        audioMixer.SetFloat("BGM", volume);
        audioMixer.SetFloat("SE", volume);
    }
    */

   
    public void BGMVolume(float value)
    {
        value = bgm.GetComponent<AudioSource>().volume;
    }
}
