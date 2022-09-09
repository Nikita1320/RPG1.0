using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenuState : BaseStateInput<InputActionsUI, StateUI>
{
    private InputActionsUI inputActionsUI;
    public override void Begin()
    {
        inputActionsUI.UIInGameMenuInput.Enable();
    }

    public override void Exit(StateUI nextStateUI)
    {
        inputActionsUI.UIInGameMenuInput.Disable();
    }
    public override void Init(InputActionsUI _inputActionsUI)
    {
        inputActionsUI = _inputActionsUI;
    }
}
