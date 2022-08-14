using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultStateUI : BaseStateInput
{
    private InputController inputController;
    public override void Begin()
    {
        inputController.UIDefaultInput.Enable();
    }

    public override void Exit()
    {
        inputController.UIDefaultInput.Disable();
    }
    public override void Init(InputController _inputController)
    {
        inputController = _inputController;
    }
}
