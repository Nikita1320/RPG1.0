using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States
{
    Default,
    InAir,
    Block,
    Jerk
}
public class StateMachine : MonoBehaviour
{
    public delegate void ChangeStateEvent(States _state);
    public ChangeStateEvent changeStateEvent;

    public delegate void MoveEvent(Vector2 direction);
    public MoveEvent moveEvent;

    public delegate void JumpEvent();
    public JumpEvent jumpEvent;

    public delegate void JerkEvent();
    public JerkEvent jerkEvent;

    public delegate void BlockEvent();
    public BlockEvent blockEvent;

    public delegate void ExitBlockEvent();
    public ExitBlockEvent exitBlockEvent;

    public delegate void AbilityEvent(int abilityNumber);
    public AbilityEvent ability1Event;

    public delegate void ConsumableEvent(int consumableNumber);
    public ConsumableEvent consumable1Event;

    public InputController inputController;

    private List<BaseStateInput> states = new List<BaseStateInput>();
    public BaseStateInput currentState;

    void Start()
    {
        inputController = new InputController();
        inputController.Enable();

        InitState();
    }

    void FixedUpdate()
    {
        currentState.FixedUpdate();
    }

    public void ChangeState(States _state = States.Default)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = states[(int)_state];
        currentState.Begin();

        changeStateEvent?.Invoke(_state);
        Debug.Log(currentState);
    }
    public void InitState()
    {
        states.Add(new DefaultStateInput());
        states.Add(new InAirState());
        states.Add(new ShieldStateInput());
        states.Add(new JerkState());

        for (int i = 0; i < states.Count; i++)
        {
            states[i].Init(this);
            Debug.Log(states[i]);
        }

        ChangeState();
    }
}
