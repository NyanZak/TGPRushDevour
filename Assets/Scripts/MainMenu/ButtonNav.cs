using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonNav : MonoBehaviour
{
    public Button[] buttons;
    public float buttonRate;
    public float longPressTime;
    private float pressTime = 0;
    private bool pressing;
    [HideInInspector]public float nextButtonTime;
    [HideInInspector]public int buttonIndex = 0;
    MouseState currentState;
    public readonly PlayState playState = new PlayState();
    public readonly OptionState optionState = new OptionState();
    public readonly AccessState accessState = new AccessState();
    public readonly WeaponsState weaponsState = new WeaponsState();
    public readonly QuitState quitState = new QuitState();

    void Start()
    {
        pressing = false;
        foreach (var item in buttons)
        {
            item.enabled = false;
        }
        TransitionToState(playState);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ButtonDown();
        }
        if (Input.GetMouseButtonUp(0))
        {
            ButtonUp();
        }
        currentState.UpdateState(this, buttons[buttonIndex]);
        if (pressing)
        {
            if (Time.time > pressTime)
            {
                currentState.ActionState(this, buttons[buttonIndex]);
                pressing = false;
            }
        }
    }
    public void ButtonDown()
    {
        pressing = true;
        pressTime = Time.time + longPressTime;
    }
    public void ButtonUp()
    {
        pressing = false;
        currentState.ExitState(this,buttons[buttonIndex]);
    }
    public void ButtonClick(string message)
    {
        Debug.Log(message);
    }    
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void TransitionToState(MouseState state)
    {
        nextButtonTime = Time.time + buttonRate;
        currentState = state;
        currentState.EnterState(this, buttons[buttonIndex]);
    }
}