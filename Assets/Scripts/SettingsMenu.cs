using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class SettingsMenu : MonoBehaviour
{
    Resolution[] resolutions;
    int currentResolutionIndex = 0;
    int index = 0;
    public string[] qualityLevels;
    public string[] modes = { "off", "on" };
    public float[] gameSpeeds;
    public float[] cameraFOVS;
    public static float currentCameraFOV = 60f; 
    public static float currentGameSpeed = 1f;
    public GameManager gameManager;
    // public TextMeshProUGUI textComponent;
    // public AudioMixer AudioMixer;
    // public AudioMixerGroup MusicMixer;
    // public AudioMixerGroup SFXMixer;
    public TextMeshProUGUI resolutionText, fullscreenText, graphicsText, fovText, gameSpeedText, colourblindText;
    private void Start()
    {
        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].width == Screen.width &&
                resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
                break;
            }
        }
        resolutionText.text = $"{resolutions[currentResolutionIndex].width} x {resolutions[currentResolutionIndex].height}";
        qualityLevels = new string[] { "Very Low", "Low", "Medium", "High" , "Very High", "Ultra" };
        graphicsText = GameObject.Find("GraphicsText").GetComponent<TextMeshProUGUI>();
        QualitySettings.SetQualityLevel(6);
        graphicsText.text = qualityLevels[QualitySettings.GetQualityLevel()];
        if (!PlayerPrefs.HasKey("colourblind"))
        {
            PlayerPrefs.SetString("colourblind", "off");
            colourblindText.text = "off";
        }
        else
        {
            string colourblind = PlayerPrefs.GetString("colourblind");
            colourblindText.text = colourblind;
        }
        currentGameSpeed = gameSpeeds[0];
        gameSpeedText.text = currentGameSpeed.ToString();
    }
    void Update()
    {
        fullscreenText.text = Screen.fullScreen ? "Fullscreen" : "Windowed";
    }
    public void ChangeResolution()
    {
        currentResolutionIndex++;
        if (currentResolutionIndex >= resolutions.Length)
        {
            currentResolutionIndex = 0;
        }
        if (resolutions.Length == 0)
        {
            return;
        }
        Resolution resolution = resolutions[currentResolutionIndex]; Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        resolutionText.text = $"{resolution.width} x {resolution.height}";
    }
    public void ToggleFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
    public void ApplyQuality()
    {
        int currentQualityLevel = QualitySettings.GetQualityLevel();
        if (currentQualityLevel == qualityLevels.Length - 1)
        {
            QualitySettings.SetQualityLevel(0);
        }
        else
        {
            QualitySettings.SetQualityLevel(currentQualityLevel + 1);
        }
        string currentQualityLevelName = qualityLevels[QualitySettings.GetQualityLevel()];
        graphicsText.text = currentQualityLevelName;
    }
    public void SetVolume(string audioTrack, float volume)
        {
           // AudioMixer.SetFloat(audioTrack, volume);
        }
    // public void DecreaseVolume(string audioTrack)
    //  {
    //    float currentVolume;
    // AudioMixer.GetFloat(audioTrack, out currentVolume);
    //    if (currentVolume > 0.0f)
    //     {
    //          // Decrease the volume by 10%
    //         float newVolume = Mathf.Max(currentVolume - 10.0f, 0.0f);
    //         SetVolume(audioTrack, newVolume);
    //    }
    //    else
    //    {
    //       SetVolume(audioTrack, 100.0f);
    //   }
    //  }
 
    public void SetGameSpeed()
    {
        int index = System.Array.IndexOf(gameSpeeds, currentGameSpeed);
        currentGameSpeed = (index + 1 < gameSpeeds.Length) ? gameSpeeds[index + 1] : gameSpeeds[0];
        gameManager.SetTimeScale(currentGameSpeed);
        gameSpeedText.text = currentGameSpeed.ToString();
    }
    public void SetCameraFOV()
    {
        int index = System.Array.IndexOf(cameraFOVS, currentCameraFOV);
        currentCameraFOV = (index + 1 < cameraFOVS.Length) ? cameraFOVS[index + 1] : cameraFOVS[0];
        gameManager.SetCameraFOV(currentCameraFOV);
        fovText.text = currentCameraFOV.ToString();
    }
    public void ChangeColourblindMode()
    {
        if (PlayerPrefs.HasKey("colourblind"))
        {
            string colourblind = PlayerPrefs.GetString("colourblind");
            colourblindText.text = colourblind;
            if (colourblind == "off")
            {
                PlayerPrefs.SetString("colourblind", "on");
            }
            else
            {
                PlayerPrefs.SetString("colourblind", "off");
            }
        }
        else
        {
            PlayerPrefs.SetString("colourblind", "on");
        }
        colourblindText.text = PlayerPrefs.GetString("colourblind");
    }

    
} 