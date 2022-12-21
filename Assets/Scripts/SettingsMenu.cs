using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SettingsMenu : MonoBehaviour
{
    Resolution[] resolutions;
    int currentResolutionIndex = 0;
    int index = 0;
    public string[] qualityLevels;
    public string[] modes = { "off", "on" };
    public float[] gameSpeeds;
    public float[] cameraFOVS;
    public float[] exposures;
    public float[] contrasts;
    public static float currentExposure = 0.5f;
    public static float currentContrast = 0f;
    public static float currentCameraFOV = 60.0f; 
    public static float currentGameSpeed = 1f;
    public GameManager gameManager;
    public AudioMixer overallMixer;
    public AudioMixerGroup VoiceoverMixer;
    public AudioMixerGroup SFXMixer;
    public TextMeshProUGUI resolutionText, fullscreenText, graphicsText, brightnessText, contrastText, fovText, sfxText, voiceoverText, overallText, gameSpeedText, colourblindText;
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
        fovText.text = currentCameraFOV.ToString();
        brightnessText.text = currentExposure.ToString();
        contrastText.text = currentContrast.ToString();
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
    public void OverallVolume()
    {
        float currentVolume;
        overallMixer.GetFloat("Volume", out currentVolume);
        float targetVolume = Mathf.Lerp(currentVolume, currentVolume - 2000, Time.deltaTime); 
        if (targetVolume < -80)
        {
            targetVolume = 20;
        }
        targetVolume = Mathf.Round(targetVolume);
        overallMixer.SetFloat("Volume", targetVolume);
        overallText.text = "" + currentVolume;
    }
    public void VoiceoverMixerVolume()
    {
        float currentVolume;
        VoiceoverMixer.audioMixer.GetFloat("VoiceoverVolume", out currentVolume);
        float targetVolume = Mathf.Lerp(currentVolume, currentVolume - 2000, Time.deltaTime);
        if (targetVolume < -80)
        {
            targetVolume = 20;
        }
        targetVolume = Mathf.Round(targetVolume);
        VoiceoverMixer.audioMixer.SetFloat("VoiceoverVolume", targetVolume);
        voiceoverText.text = "" + currentVolume;
    }
    public void SFXMixerVolume()
    {
        float currentVolume;
        VoiceoverMixer.audioMixer.GetFloat("SFXVolume", out currentVolume);
        float targetVolume = Mathf.Lerp(currentVolume, currentVolume - 2000, Time.deltaTime);
        if (targetVolume < -80)
        {
            targetVolume = 20;
        }
        targetVolume = Mathf.Round(targetVolume);
        SFXMixer.audioMixer.SetFloat("SFXVolume", targetVolume);
        sfxText.text = "" + currentVolume;
    }
    public void SetPostExposure()
    {
        int index = System.Array.IndexOf(exposures, currentExposure);
        currentExposure = (index + 1 < exposures.Length) ? exposures[index + 1] : exposures[0];
        gameManager.SetPostExposure(currentExposure);
        brightnessText.text = currentExposure.ToString();
        Debug.Log(currentExposure);
    }
    public void SetContrast()
    {
        int index = System.Array.IndexOf(contrasts, currentContrast);
        currentContrast = (index + 1 < contrasts.Length) ? contrasts[index + 1] : contrasts[0];
        gameManager.SetContrast(currentContrast);
        contrastText.text = currentContrast.ToString();
        Debug.Log(currentCameraFOV);
    }
    public void SetCameraFOV()
    {
        int index = System.Array.IndexOf(cameraFOVS, currentCameraFOV);
        currentCameraFOV = (index + 1 < cameraFOVS.Length) ? cameraFOVS[index + 1] : cameraFOVS[0];
        gameManager.SetCameraFOV(currentCameraFOV);
        fovText.text = currentCameraFOV.ToString();
        Debug.Log(currentCameraFOV);
    }
    public void SetGameSpeed()
    {
        int index = System.Array.IndexOf(gameSpeeds, currentGameSpeed);
        currentGameSpeed = (index + 1 < gameSpeeds.Length) ? gameSpeeds[index + 1] : gameSpeeds[0];
        gameManager.SetTimeScale(currentGameSpeed);
        gameSpeedText.text = currentGameSpeed.ToString();
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