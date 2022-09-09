using UnityEngine;

public class PlayerAbilityManager : AbilityManagerBase
{
    private InputController inputController;
    private AnimatorManager animatorManager;

    [SerializeField] private AbilitySlotQuickAccess[] abilitySlot;
    private AbilitySlotQuickAccess currentUseAbilitySlot;

    private void Start()
    {
        inputController = GetComponent<InputController>();
        animatorManager = GetComponent<AnimatorManager>();
        SubscribeOnEvent();
        InitSlot();
    }

    public override void StartAbility(int index)
    {
        abilitySlot[index].StartAbility();
        currentUseAbilitySlot = abilitySlot[index];
    }
    public override void AnimationEvent()
    {
        currentUseAbilitySlot.Use();
    }
    public override void EndAbility()
    {
        inputController.ChangeState(States.Default);
    }
    public void SubscribeOnEvent()
    {
        inputController.exitStateEvent += ExitState;
        inputController.startStateEvent += StartState;
        inputController.abilityEvent += StartAbility;
    }
    protected override void InitSlot()
    {
        for (int i = 0; i < abilitySlot.Length; i++)
        {
            abilitySlot[i].Init(i, inputController, animatorManager);
        }
    }
    private void StartState(States _state)
    {

    }

    private void ExitState(States _state)
    {

    }
}
