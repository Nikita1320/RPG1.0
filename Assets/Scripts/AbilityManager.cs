using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    [SerializeField] private AbilitySlotQuickAccess[] abilitySlot;
    private AbilitySlotQuickAccess currentUseAbilitySlot;

    private Character character;
    private StateMachine stateMachine;

    private void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        character = GetComponent<Character>();
        stateMachine.changeStateEvent += ChangeState;
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

    public void ChangeState(States _state)
    {
        if (_state == States.Default)
        {
            SubscribeOnAbilityEvent();
        }
    }

    public void SubscribeOnAbilityEvent()
    {
        stateMachine.abilityEvent += StartAbility;
    }

    private void InitSlot()
    {
        for (int i = 0; i < abilitySlot.Length; i++)
        {
            abilitySlot[i].Init(character);
        }
    }
}
