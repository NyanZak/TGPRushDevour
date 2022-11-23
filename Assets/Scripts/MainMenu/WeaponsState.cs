using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsState : MouseState
{
    public override void UpdateState(ButtonNav buttonNav, Button button)
    {
        
    }

    public override void EnterState(ButtonNav buttonNav, Button button)
    {
        button.enabled = true;
        button.Select();
        Debug.Log("Weapons");
    }

    public override void ExitState(ButtonNav buttonNav, Button button)
    {
        button.enabled = false;
        buttonNav.buttonIndex += 1;
        if (buttonNav.buttonIndex == buttonNav.buttons.Length)
        {
            buttonNav.buttonIndex = 0;
        }
        buttonNav.TransitionToState(buttonNav.quitState);
    }

    public override void ActionState(ButtonNav buttonNav, Button button)
    {
        Debug.Log("Weapons Action");
    }
}
