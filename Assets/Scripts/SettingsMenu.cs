using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audiomusicMixer;
    public AudioMixer audiosfxMixer;

    public void SetMusicVolume (float volume)
    {
        audiomusicMixer.SetFloat("musicVolume", volume);
    }

    
    public void SetSFXVolume(float volume)
    {
        audiosfxMixer.SetFloat("sfxVolume", volume);
    }
}
