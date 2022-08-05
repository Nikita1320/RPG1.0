using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySlotQuickAccess : MonoBehaviour
{
    public AbilityConteiner abilityConteiner;
    public AbilityBase ability;
    private Character character;
    //private AnimatorManager animatorManager;

    [SerializeField] private string nameAnimationInBaseAnimator;

    public void AddAbility(AbilityConteiner _abilityConteiner)
    {
        abilityConteiner = _abilityConteiner;
        abilityConteiner.currentSlot = this;
        /*if (abilityConteiner.ability.typeAbility = AbilityType.Active)
        {
            anmatorManager.ChangeAnimationClip(nameAnimationInBaseAnimator, abilityConteiner.ability.animationClip;
        }*/
    }
    public void ClearSlot(bool moveToTreeCurrentAbility)
    {
        if (moveToTreeCurrentAbility && abilityConteiner != null)
        {
            abilityConteiner.ReturnAbilityToTree();
        }
        abilityConteiner = null;
    }
    public void StartAbility()
    {
        if (abilityConteiner != null && abilityConteiner.ability.canBeUsed)
        {
            abilityConteiner.ability.StartAbility(character);
        }
    }
    public void Use()
    {
        abilityConteiner.ability.Use();
    }
    public void Init(Character _character)
    {
        character = _character;
        //animatorManager = character.gameobject.GetComponent<AnimatorManager>();
    }
}
