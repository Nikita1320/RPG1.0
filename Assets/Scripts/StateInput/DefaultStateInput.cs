using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultStateInput : BaseStateInput
{
    private StateMachine stateMachine;
    public override void Begin()
    {
        stateMachine.inputController.Default.Jump.performed += context => stateMachine.jumpEvent?.Invoke();
        stateMachine.inputController.Default.Block.performed += context => stateMachine.blockEvent?.Invoke();
        stateMachine.inputController.Default.Jerk.performed += context => stateMachine.jerkEvent?.Invoke();

        stateMachine.inputController.Default.Ability1.performed += context => stateMachine.abilityEvent?.Invoke(1);
        stateMachine.inputController.Default.Ability1.performed += context => stateMachine.abilityEvent?.Invoke(2);
        stateMachine.inputController.Default.Ability1.performed += context => stateMachine.abilityEvent?.Invoke(3);
        stateMachine.inputController.Default.Ability1.performed += context => stateMachine.abilityEvent?.Invoke(4);
        stateMachine.inputController.Default.Ability1.performed += context => stateMachine.abilityEvent?.Invoke(5);
    }

    public override void Exit()
    {
        stateMachine.jumpEvent = null;
        stateMachine.blockEvent = null;
        stateMachine.jerkEvent = null;
    }

    public override void FixedUpdate()
    {
        stateMachine.moveEvent?.Invoke(stateMachine.inputController.Default.Move.ReadValue<Vector2>());
    }

    public override void Init(StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
}
