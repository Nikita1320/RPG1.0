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
public class InputController : MonoBehaviour
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

    private InputActions inputs;
    
    private List<BaseStateInput<InputActions, States>> states = new List<BaseStateInput<InputActions, States>>();
    private States currentState;
    public InputActions Inputs => inputs;
    public States CurrentState => currentState;

    void Awake()
    {
        inputs = new InputActions();
    }
    private void Start()
    {
        currentState = States.Disable;
        InitEvent();
        InitState();
    }

    private void FixedUpdate()
    {
        if (currentState == States.Default)
        {
            moveEvent?.Invoke(inputs.Default.Move.ReadValue<Vector2>());
        }
    }

    public void ChangeState(States nextState)
    {
        exitStateEvent?.Invoke(currentState);

        if ((int)currentState < states.Count)
        {
            states[(int)currentState].Exit(nextState);
        }

        currentState = nextState;

        if ((int)currentState < states.Count)
        {
            states[(int)nextState].Begin();
        }

        startStateEvent?.Invoke(nextState);
    }
    private void InitState()
    {
        states.Add(new DefaultStateInput());
        states.Add(new BlockStateInput());
        states.Add(new AttackStateInput());

        for (int i = 0; i < states.Count; i++)
        {
            states[i].Init(inputs);
        }

        ChangeState(States.Default);
    }
    private void InitEvent()
    {
        inputs.Default.Jump.performed += context => jumpEvent?.Invoke();
        inputs.Default.Jerk.performed += context => jerkEvent?.Invoke();
        inputs.Default.Block.performed += context => blockEvent?.Invoke();
        inputs.InBlock.ExitBlock.performed += context => exitBlockEvent?.Invoke();
        inputs.Default.Attack.performed += context => attackEvent?.Invoke();
        inputs.Attack.Attack.performed += context => attackEvent?.Invoke();

        inputs.Default.Ability1.performed += context => abilityEvent?.Invoke(0);
        inputs.Default.Ability2.performed += context => abilityEvent?.Invoke(1);
        inputs.Default.Ability3.performed += context => abilityEvent?.Invoke(2);
        inputs.Default.Ability4.performed += context => abilityEvent?.Invoke(3);
        inputs.Default.Ability5.performed += context => abilityEvent?.Invoke(4);

        inputs.Default.Consumables1.performed += context => consumableEvent?.Invoke(0);
        inputs.Default.Consumables2.performed += context => consumableEvent?.Invoke(1);
    }
    public void RefreshCurrentState()
    {
        states[(int)currentState].Begin();
    }
}
