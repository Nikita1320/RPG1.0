using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public delegate void ChangeCooldownReduction(float CooldownReduction);
    public ChangeCooldownReduction changeCooldownReductionEvent;
    
    private StateMachine stateMachine;
    private AnimatorManager animatorManager;

    [SerializeField] private AbilitySlotQuickAccess[] abilitySlot;
    private AbilitySlotQuickAccess currentUseAbilitySlot;

    [SerializeField] private float baseCooldownReduction = 1;
    private float ñoefficientOfChangeCooldownReduction = 1;

    public float CurrentCooldownReduction { get { return baseCooldownReduction * ÑoefficientOfChangeCooldownReduction; } }
    public float ÑoefficientOfChangeCooldownReduction { private get { return ñoefficientOfChangeCooldownReduction; } set { ñoefficientOfChangeCooldownReduction *= value; changeCooldownReductionEvent(CurrentCooldownReduction); } }

    private void Start()
    {
        stateMachine = GetComponent<StateMachine>();
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
            abilitySlot[i].Init(i, stateMachine, animatorManager);
        }
    }
}
