using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    [SerializeField] private AbilitySlotQuickAccess[] abilitySlot;
    private AbilitySlotQuickAccess currentUseAbilitySlot;

    private Character character;
    private StateMachine stateMachine;
    private AnimatorManager animatorManager;

    private void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        character = GetComponent<Character>();
        animatorManager = GetComponent<AnimatorManager>();
        SubscribeOnEvent();
        InitSlot();
    }

    private void StartAbility(int index)
    {
        abilitySlot[index].StartAbility();
        currentUseAbilitySlot = abilitySlot[index];
    }
    public void AnimationEvent()
    {
        currentUseAbilitySlot.Use();
    }

    public void ExitState(States _state)
    {

    }

    public void StartState(States _state)
    {

    }

    public void SubscribeOnEvent()
    {
        stateMachine.exitStateEvent += ExitState;
        stateMachine.startStateEvent += StartState;
        stateMachine.abilityEvent += StartAbility;
    }

    private void InitSlot()
    {
        for (int i = 0; i < abilitySlot.Length; i++)
        {
            abilitySlot[i].Init(character, i, stateMachine, animatorManager);
        }
    }
}
