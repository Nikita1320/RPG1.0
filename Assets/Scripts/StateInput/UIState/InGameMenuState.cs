using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenuState : BaseStateInput
{
    private InputController inputController;
    public override void Begin()
    {
        inputController.UIInGameMenuInput.Enable();
    }

    public override void Exit()
    {
        inputController.UIInGameMenuInput.Disable();
    }
    public override void Init(InputController _inputController)
    {
        inputController = _inputController;
    }
}
