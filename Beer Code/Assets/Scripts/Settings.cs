using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Security.Cryptography.X509Certificates;

public class Settings : MonoBehaviour
{
    public Slider SlideVolume;
    public Dropdown resolutionsDropdown;
    public Dropdown qualityDropdown;

    Resolution[] resolutions;

    void Start()
    {
        resolutionsDropdown.ClearOptions();
        List<string> option = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string options = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            option.Add(options);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;

        }

        resolutionsDropdown.AddOptions(option);
        resolutionsDropdown.RefreshShownValue();
        LoadSettings(currentResolutionIndex);
    }

    public void SetResolution(int resolutonIndex)
    {
        Resolution resolution = resolutions[resolutonIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    
    public void SaveAndExit()
    {
        SceneManager.LoadScene("MainMenu");
        PlayerPrefs.SetInt("QaulitySettingsPreference", qualityDropdown.value);
        PlayerPrefs.SetInt("ResolutionPreference", resolutionsDropdown.value);
        
    }

    public void Volume()
    {
        AudioListener.volume = SlideVolume.value;
    }

    public void LoadSettings(int currentResolutionIndex)
    {
        if (PlayerPrefs.HasKey("QualitySettingsPreference"))
            qualityDropdown.value = PlayerPrefs.GetInt("QualitySettingsPrefernce");
        else
            qualityDropdown.value = 3;

        if (PlayerPrefs.HasKey("ResolutionPreference"))
            resolutionsDropdown.value = PlayerPrefs.GetInt("ResolutionPreference");
        else
            resolutionsDropdown.value = currentResolutionIndex;

    }
    


}   

