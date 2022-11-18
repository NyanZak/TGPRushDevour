using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonNav : MonoBehaviour
{
    public Button[] buttons;
    public float buttonRate;
    float nextButtonTime;
    int buttonIndex = 0;
    
    void Start()
    {
        nextButtonTime = Time.time + buttonRate;
        foreach (var item in buttons)
        {
            item.enabled = false;
        }
        buttons[0].enabled = true;
    }
    void Update()
    {
        float fire = Input.GetAxis("Fire1");
        if (fire > 0)
        {
            buttons[buttonIndex].Select();
            if (Time.time > nextButtonTime)
            {
                buttons[buttonIndex].enabled = false;
                buttonIndex += 1;
                if (buttonIndex == buttons.Length)
                {
                    buttonIndex = 0;
                }
                buttons[buttonIndex].enabled = true;
                buttons[buttonIndex].Select();
                nextButtonTime = Time.time + buttonRate;
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                buttons[buttonIndex].onClick.Invoke();
            }
            buttonIndex = 0;
            buttons[buttonIndex].enabled = true;
            nextButtonTime = Time.time + buttonRate;
        }
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
}