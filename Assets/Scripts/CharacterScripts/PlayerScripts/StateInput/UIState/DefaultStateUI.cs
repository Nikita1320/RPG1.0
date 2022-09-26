using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultStateUI : BaseStateInput<InputActionsUI, StateUI>
{
    private InputActionsUI inputActionsUI;
    public override void Begin()
    {
        inputActionsUI.UIDefaultInput.Enable();
    }

    public override void Exit(StateUI nextStateUI)
    {
        inputActionsUI.UIDefaultInput.Disable();
    }
    public override void Init(InputActionsUI _inputActionsUI)
    {
        inputActionsUI = _inputActionsUI;
    }
}
