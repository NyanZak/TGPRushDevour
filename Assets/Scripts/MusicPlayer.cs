using UnityEngine;
using UnityEngine.SceneManagement;
public class MusicPlayer : MonoBehaviour
{
    static Object instance = null;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "TutorialLevel")
        {
            Destroy(this.gameObject);
        }
    }
}