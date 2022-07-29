using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldStateInput : BaseStateInput
{
    private StateMachine stateMachine;
    public override void Begin()
    {
        stateMachine.inputController.Default.ExitBlock.performed += context => stateMachine.exitBlockEvent?.Invoke();
    }

    public override void Exit()
    {
        stateMachine.exitBlockEvent = null;
    }

    public override void FixedUpdate()
    {

    }
    public override void Init(StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
}
