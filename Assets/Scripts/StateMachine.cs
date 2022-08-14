using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States
{
    Default,
    Block,
    Attack,
    InAir,
    UseAbility,
    UseConsumables,
    Jerk,
    Disable
}
public class StateMachine : MonoBehaviour
{
    public delegate void StartStateEvent(States _state);
    public StartStateEvent startStateEvent;

    public delegate void ExitStateEvent(States _state);
    public ExitStateEvent exitStateEvent;

    public delegate void MoveEvent(Vector2 direction);
    public MoveEvent moveEvent;

    public delegate void AttackEvent();
    public AttackEvent attackEvent;

    public delegate void JumpEvent();
    public JumpEvent jumpEvent;

    public delegate void JerkEvent();
    public JerkEvent jerkEvent;

    public delegate void BlockEvent();
    public BlockEvent blockEvent;

    public delegate void ExitBlockEvent();
    public ExitBlockEvent exitBlockEvent;

    public delegate void AbilityEvent(int abilityNumber);
    public AbilityEvent abilityEvent;

    public delegate void ConsumableEvent(int consumableNumber);
    public ConsumableEvent consumableEvent;

    public InputController inputController;

    private List<BaseStateInput> states = new List<BaseStateInput>();
    public BaseStateInput currentState1;
    public States currentState;

    void Awake()
    {
        inputController = new InputController();
    }
    private void Start()
    {
        currentState = States.Disable;
        InitEvent();
        InitState();
    }

    void FixedUpdate()
    {
        if (currentState == States.Default)
        {
            moveEvent?.Invoke(inputController.Default.Move.ReadValue<Vector2>());
        }
    }

    public void ChangeState(States _state)
    {
        if (currentState == States.Default && _state != States.Block)
        {
            inputController.InBlock.Disable();
        }

        exitStateEvent?.Invoke(currentState);

        if ((int)currentState < 3)
        {
            states[(int)currentState].Exit();
        }

        currentState = _state;

        if ((int)currentState < 3)
        {
            states[(int)_state].Begin();
        }

        startStateEvent?.Invoke(_state);
    }
    public void InitState()
    {
        states.Add(new DefaultStateInput());
        states.Add(new BlockStateInput());
        states.Add(new AttackStateInput());

        for (int i = 0; i < states.Count; i++)
        {
            states[i].Init(inputController);
        }

        ChangeState(States.Default);
    }
    public void InitEvent()
    {
        inputController.Default.Jump.performed += context => jumpEvent?.Invoke();
        inputController.Default.Jerk.performed += context => jerkEvent?.Invoke();
        inputController.Default.Block.performed += context => blockEvent?.Invoke();
        inputController.InBlock.ExitBlock.performed += context => exitBlockEvent?.Invoke();
        inputController.Default.Attack.performed += context => attackEvent?.Invoke();
        inputController.Attack.Attack.performed += context => attackEvent?.Invoke();

        inputController.Default.Ability1.performed += context => abilityEvent?.Invoke(0);
        inputController.Default.Ability2.performed += context => abilityEvent?.Invoke(1);
        inputController.Default.Ability3.performed += context => abilityEvent?.Invoke(2);
        inputController.Default.Ability4.performed += context => abilityEvent?.Invoke(3);
        inputController.Default.Ability5.performed += context => abilityEvent?.Invoke(4);

        inputController.Default.Consumables1.performed += context => consumableEvent?.Invoke(0);
        inputController.Default.Consumables2.performed += context => consumableEvent?.Invoke(1);
    }
    public void RefreshCurrentState()
    {
        states[(int)currentState].Begin();
    }
}
