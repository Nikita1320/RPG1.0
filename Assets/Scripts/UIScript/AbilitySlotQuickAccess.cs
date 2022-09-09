using UnityEngine;

public class AbilitySlotQuickAccess : MonoBehaviour
{
    [SerializeField] private string nameAnimationInBaseAnimator;
    [SerializeField]private AbilityConteiner abilityConteiner;

    private InputController inputController;
    private AnimatorManager animatorManager;
    private int indexSlot;
    
    private AbilityBase ability;

    private bool slotIsBlocked = false;

    public AbilityConteiner AbilityConteinerInSlot => abilityConteiner;
    public bool SlotIsBlocked => slotIsBlocked;
    public void AddAbility(AbilityConteiner _abilityConteiner)
    {
        abilityConteiner = _abilityConteiner;

        ability = abilityConteiner.gameObject.GetComponent<AbilityBase>();

        if (ability.TryGetComponent(out ActiveAbilityBase activeAbility))
        {
            animatorManager.ChangeAnimation(nameAnimationInBaseAnimator, activeAbility.Animation);
            activeAbility.endCoolDownTimerEvent += EnableDragDrop;
        }
        else
        {
            ability.Begin(inputController.gameObject);
        }
    }
    public void ClearSlot(bool returnAbilityToTree)
    {
        if (abilityConteiner && !slotIsBlocked)
        {
            if (returnAbilityToTree)
            {
                abilityConteiner.ReturnAbilityToTree();
                if (ability.TryGetComponent(out PassiveAbilityBase passiveAbility))
                {
                    passiveAbility.EndAbility();
                }
            }
            if (ability.TryGetComponent(out ActiveAbilityBase activeAbility))
            {
                activeAbility.endCoolDownTimerEvent -= EnableDragDrop;
            }
            abilityConteiner = null;
        }
    }
    public void StartAbility()
    {
        if (abilityConteiner && ability.TryGetComponent(out ActiveAbilityBase activeAbility) && activeAbility.IsReadyToUse)
        {
            animatorManager.Animator.SetInteger("AbilityIndex", indexSlot);
            animatorManager.Animator.SetTrigger("ActiveAbility");
            activeAbility.Begin(inputController.gameObject);
            inputController.ChangeState(States.UseAbility);
            DisableDragDrop();
        }
    }
    public void Use()
    {
        ability.GetComponent<ActiveAbilityBase>().Use();
    }
    public void Init(int _indexSlot, InputController _inputController, AnimatorManager _animatorManager)
    {
        indexSlot = _indexSlot;
        inputController = _inputController;
        animatorManager = _animatorManager;
    }
    private void DisableDragDrop()
    {
        GetComponent<DropAbility>().enabled = false;
        abilityConteiner.gameObject.GetComponent<Drag>().enabled = false;
        slotIsBlocked = true;
    }
    private void EnableDragDrop()
    {
        GetComponent<DropAbility>().enabled = true;
        abilityConteiner.gameObject.GetComponent<Drag>().enabled = true;
        slotIsBlocked = false;
    }
}
