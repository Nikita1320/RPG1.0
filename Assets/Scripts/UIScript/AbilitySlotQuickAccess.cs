using UnityEngine;

public class AbilitySlotQuickAccess : MonoBehaviour
{
    [SerializeField] private string nameAnimationInBaseAnimator;

    [SerializeField]private AbilityConteiner abilityConteiner;
    private AbilityBase ability;

    private int indexSlot;
    private StateMachine stateMachine;
    private AnimatorManager animatorManager;
    private CoolDown coolDown;
    public AbilityConteiner AbilityConteinerInSlot => abilityConteiner;

    private void Start()
    {
        coolDown = GetComponent<CoolDown>();
        coolDown.endCoolDownEvent += EnableDragDrop;
    }
    public void AddAbility(AbilityConteiner _abilityConteiner)
    {
        abilityConteiner = _abilityConteiner;

        ability = abilityConteiner.gameObject.GetComponent<AbilityBase>();

        /*if (ability.TypeAbility == TypeAbility.Active)
        {
            animatorManager.ChangeAnimation(nameAnimationInBaseAnimator, ability.GetComponent<ActiveAbilityBase>().Animation);
        }
        else
        {
            ability.Begin(stateMachine.gameObject);
        }*/
    }
    public void ClearSlot(bool returnAbilityToTree)
    {
        if (abilityConteiner && !coolDown.TimerIsRun)
        {
            if (returnAbilityToTree)
            {
                abilityConteiner.ReturnAbilityToTree();
                if (ability.TypeAbility == TypeAbility.Passive)
                {
                    ability.GetComponent<PassiveAbilityBase>().EndAbility();
                }
            }
            abilityConteiner = null;
        }
    }
    public void StartAbility()
    {
        if (abilityConteiner && ability.TypeAbility == TypeAbility.Active && !coolDown.TimerIsRun)
        {
            ability.Begin(stateMachine.gameObject);
            coolDown.StartTimer(ability.GetComponent<ActiveAbilityBase>().CoolDown);
            DisableDragDrop();
        }
    }
    public void Use()
    {
        ability.GetComponent<ActiveAbilityBase>().Use();
    }
    public void Init(int _indexSlot, StateMachine _stateMachine, AnimatorManager _animatorManager)
    {
        indexSlot = _indexSlot;
        stateMachine = _stateMachine;
        animatorManager = _animatorManager;
    }
    private void DisableDragDrop()
    {
        GetComponent<DropAbility>().enabled = false;
        abilityConteiner.gameObject.GetComponent<Drag>().enabled = false;
    }
    private void EnableDragDrop()
    {
        GetComponent<DropAbility>().enabled = true;
        abilityConteiner.gameObject.GetComponent<Drag>().enabled = true;
    }
}
