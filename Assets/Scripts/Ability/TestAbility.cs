using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestAbility: ActiveAbilityBase
{
    private GameObject character;
    public override void Begin(GameObject _character)
    {
        character = _character;
        //character.gameObject.GetComponent<StateMachine>().ChangeState(States.Ability);
        //animatorManager(Запуск анимации)
    }
    public override void Use() 
    {

    }
}
