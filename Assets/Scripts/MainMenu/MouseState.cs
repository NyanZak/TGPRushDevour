using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class MouseState
{
    public abstract void EnterState(ButtonNav buttonNav, Button button);

    public abstract void UpdateState(ButtonNav buttonNav, Button button);

    public abstract void ExitState(ButtonNav buttonNav, Button button);

    public abstract void ActionState(ButtonNav buttonNav, Button button);
    
}
