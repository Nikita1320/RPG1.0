using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockStateInput : BaseStateInput<InputActions, States>
{
    private InputActions inputActions;
    public override void Begin()
    {

    }

    public override void Exit(States nextState)
    {
        inputActions.InBlock.Disable();
    }

    public override void Init(InputActions _inputActions)
    {
        inputActions = _inputActions;
    }
}
