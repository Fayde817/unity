using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    private Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;

    private void Start()
    {
        resolutions = Screen.resolutions;
        
        resolutionDropdown.ClearOptions();

        int currentResolIndex = 0;
        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height) 
            {
                currentResolIndex = i;
            }
        }
            
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolIndex;
        resolutionDropdown.RefreshShownValue();

    } 
    

    public void SetVolume(float vol)
    {
        audioMixer.SetFloat("Volume", vol);
    }   

    public void SetQuality ( int qual)
    {
        QualitySettings.SetQualityLevel(qual);
    }

    public void SetFullscreen(bool FullOuPas)
    {
        Screen.fullScreen = FullOuPas;
    }
}
