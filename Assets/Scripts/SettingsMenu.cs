using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;
    //public Slider volumeSlider;

    /*private void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volume", 0.75f);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    */

 
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
