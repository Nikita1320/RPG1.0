using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultStateInput : BaseStateInput<InputActions, States>
{
    private InputActions inputActions;
    public override void Begin()
    {
        inputActions.Default.Enable();
        inputActions.InBlock.Enable();
    }

    public override void Exit(States nextState)
    {
        if (nextState != States.Block)
        {
            inputActions.InBlock.Disable();
        }
        inputActions.Default.Disable();
    }

    public override void Init(InputActions _inputActions)
    {
        inputActions = _inputActions;
    }
}
