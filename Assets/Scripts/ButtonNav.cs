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

        ColorBlock colors = buttons[0].colors;

        if (PlayerPrefs.GetString("colourblind") == "off")
        {
            colors.highlightedColor = Color.red;
            colors.selectedColor = Color.green;
        }
        else if (PlayerPrefs.GetString("colourblind") == "on")
        {
            Color orange = new Color(1f, 0.5f, 0.0f);
            colors.highlightedColor = Color.blue;
            colors.selectedColor = orange;
        }
        foreach (Button btn in buttons)
        {
            btn.colors = colors;
        }





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