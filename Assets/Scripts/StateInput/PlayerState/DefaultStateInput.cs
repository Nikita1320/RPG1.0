using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultStateInput : BaseStateInput
{
    private InputController inputController;
    public override void Begin()
    {
        inputController.Default.Enable();
        inputController.InBlock.Enable();
    }

    public override void Exit()
    {
        inputController.Default.Disable();
    }

    public override void Init(InputController _inputController)
    {
        inputController = _inputController;
    }
}
