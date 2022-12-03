using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonNav : MonoBehaviour
{
    public Button[] buttons;
    int index = 0;
    [SerializeField] private InputActionReference actionReference;
    public void OnEnable()
    {
        actionReference.action.Enable();
        Debug.Log(this + ("ENABLE"));
    }
    public void OnDisable()
    {
        actionReference.action.Disable();
    }
    private void Awake()
    {
        if (!(actionReference.action.interactions.Contains("TapInteraction") && actionReference.action.interactions.Contains("HoldInteraction")))
        {
            return;
        }
    }
    void Start()
    {
        ResetNav();
    }
    void Update()
    {
        actionReference.action.performed += context =>
        {
            print(gameObject.name);
            if (context.interaction is TapInteraction)
            {
                buttons[index].Select();
                buttons[index].enabled = false;
                index++;
                if (index >= buttons.Length)
                {
                    index = 0;
                }
                buttons[index].enabled = true;
                buttons[index].Select();
            }
            else if (context.interaction is HoldInteraction)
            {
                buttons[index].onClick.Invoke();
                index = 0;
                buttons[index].enabled = true;
            }
        };
    }
    public void ResetNav()
    {
        foreach (var item in buttons)
        {
            item.enabled = false;
        }
        index = 0;
        buttons[index].enabled = true;
        buttons[index].Select();
        actionReference.action.Reset();
        actionReference.action.Enable();
        Debug.Log(this + ("START"));
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ToggleState()
    {
        GetComponent<ButtonNav>().enabled = !GetComponent<ButtonNav>().enabled;
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}