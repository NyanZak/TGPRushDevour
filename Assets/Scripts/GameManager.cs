using UnityEngine.SceneManagement;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public float timeScale = 1.0f;
    public float zombieDetectionRange = 2.0f;
    public string difficultyLevel;
    public string cameraTag;
    public float cameraFOV = 60f;
    CinemachineVirtualCamera virtualCamera;
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        virtualCamera = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>();
    }
        void Update()
    {
        if (virtualCamera != null)
        {
            virtualCamera.m_Lens.FieldOfView = cameraFOV;
        }

         if (IsInLevel())
        {
             Time.timeScale = timeScale;
         }
         else
        {
         Time.timeScale = 1f;
        }
    }
    bool IsInLevel()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        return sceneName != "MainMenu";
    }
    public void AdjustDifficulty()
    {
        if (difficultyLevel == "easy")
        {
            zombieDetectionRange = 1.0f;
        }
        else if (difficultyLevel == "medium")
        {
            zombieDetectionRange = 2.0f;
        }
        else if (difficultyLevel == "hard")
        {
            zombieDetectionRange = 3.0f;
        }
    }

    public void SetTimeScale(float newTimeScale)
    {
        timeScale = newTimeScale;
        Time.timeScale = newTimeScale;
    }

    public void SetCameraFOV(float newCameraFOV)
    {
        cameraFOV = newCameraFOV;
        virtualCamera.m_Lens.FieldOfView = newCameraFOV;
    }
}