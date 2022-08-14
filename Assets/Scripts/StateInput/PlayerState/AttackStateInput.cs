using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStateInput : BaseStateInput
{
    private InputController inputController;
    public override void Begin()
    {
        inputController.Attack.Attack.Enable();
    }

    public override void Exit()
    {
        inputController.Attack.Attack.Disable();
    }

    public override void Init(InputController _inputController)
    {
        inputController = _inputController;
    }
}
