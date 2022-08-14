using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockStateInput : BaseStateInput
{
    private InputController inputController;
    public override void Begin()
    {

    }

    public override void Exit()
    {
        inputController.InBlock.Disable();
    }

    public override void Init(InputController _inputController)
    {
        inputController = _inputController;
    }
}
