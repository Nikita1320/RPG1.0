using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySlotQuickAccess : MonoBehaviour
{
    public AbilityConteiner abilityConteiner;
    private Character character;
    private StateMachine stateMachine;
    //private AnimatorManager animatorManager;

    [SerializeField] private string nameAnimationInBaseAnimator;
    private int indexSlot;

    public void AddAbility(AbilityConteiner _abilityConteiner)
    {
        abilityConteiner = _abilityConteiner;
        abilityConteiner.currentSlot = this;
        /*if (abilityConteiner.ability.typeAbility = AbilityType.Active)
        {
            anmatorManager.ChangeAnimationClip(nameAnimationInBaseAnimator, abilityConteiner.ability.animationClip);
        }*/
    }
    public void ClearSlot()
    {
        if (abilityConteiner && !abilityConteiner.conteinerInCoolDown)
        {
            abilityConteiner.ReturnAbilityToTree();
            abilityConteiner = null;
        }
    }
    public void StartAbility()
    {
        if (abilityConteiner && abilityConteiner.ability.typeAbility != TypeAbility.Passive && !abilityConteiner.conteinerInCoolDown)
        {
            abilityConteiner.StartTimer();
            abilityConteiner.ability.StartAbility(character);
            //AnimatorManager.animator.SetTrigger("AbilityIndex", indexSlot)
            //stateMachine.ChangeState(States.Ability);
        }
    }
    public void Use()
    {
        abilityConteiner.ability.Use();
    }
    public void Init(Character _character, int _indexSlot)
    {
        character = _character;
        indexSlot = _indexSlot;
        stateMachine = _character.gameObject.GetComponent<StateMachine>();
        //animatorManager = character.gameobject.GetComponent<AnimatorManager>();
    }
}
