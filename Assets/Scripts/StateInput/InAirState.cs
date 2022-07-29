using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InAirState : BaseStateInput
{
    private StateMachine stateMachine;
    public override void Begin()
    {

    }

    public override void Exit()
    {

    }

    public override void FixedUpdate()
    {

    }
    public override void Init(StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
}
