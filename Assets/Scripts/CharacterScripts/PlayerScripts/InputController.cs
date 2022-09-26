using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;

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

    private InputActions inputsAction;
    
    private List<BaseStateInput<InputActions, States>> states = new List<BaseStateInput<InputActions, States>>();
    private States currentState;
    public InputActions InputsAction => inputsAction;
    public States CurrentState => currentState;

    void Awake()
    {
        inputsAction = new InputActions();
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
            moveEvent?.Invoke(inputsAction.Default.Move.ReadValue<Vector2>());
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
            states[i].Init(inputsAction);
        }

        ChangeState(States.Default);
    }
    private void InitEvent()
    {
        inputsAction.Default.Jump.performed += context => jumpEvent?.Invoke();
        inputsAction.Default.Jerk.performed += context => jerkEvent?.Invoke();
        inputsAction.Default.Block.performed += context => blockEvent?.Invoke();
        inputsAction.InBlock.ExitBlock.performed += context => exitBlockEvent?.Invoke();
        inputsAction.Default.Attack.performed += context =>
        {
            RaycastResult lastRaycastResult = ((InputSystemUIInputModule)EventSystem.current.currentInputModule).GetLastRaycastResult(Mouse.current.deviceId);
            const int uiLayer = 5;
            if (!(lastRaycastResult.gameObject != null && lastRaycastResult.gameObject.layer == uiLayer))
            {
                attackEvent?.Invoke();
            }
        };
        inputsAction.Attack.Attack.performed += context => 
        {
            RaycastResult lastRaycastResult = ((InputSystemUIInputModule)EventSystem.current.currentInputModule).GetLastRaycastResult(Mouse.current.deviceId);
            const int uiLayer = 5;
            if (!(lastRaycastResult.gameObject != null && lastRaycastResult.gameObject.layer == uiLayer))
            {
                attackEvent?.Invoke();
            }
        };

        inputsAction.Default.Ability1.performed += context => abilityEvent?.Invoke(0);
        inputsAction.Default.Ability2.performed += context => abilityEvent?.Invoke(1);
        inputsAction.Default.Ability3.performed += context => abilityEvent?.Invoke(2);
        inputsAction.Default.Ability4.performed += context => abilityEvent?.Invoke(3);
        inputsAction.Default.Ability5.performed += context => abilityEvent?.Invoke(4);

        inputsAction.Default.Consumables1.performed += context => consumableEvent?.Invoke(0);
        inputsAction.Default.Consumables2.performed += context => consumableEvent?.Invoke(1);
    }
    public void RefreshCurrentState()
    {
        states[(int)currentState].Begin();
    }
}
