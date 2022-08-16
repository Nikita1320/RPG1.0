using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestAbility: AbilityBase
{
    private Character character;
    public override void Begin(Character _character)
    {
        character = _character;
        //character.gameObject.GetComponent<StateMachine>().ChangeState(States.Ability);
        //animatorManager(Запуск анимации)
    }
    public override void Use() 
    {

    }
    public override void EndAbility()
    {
        //character.gameObject.GetComponent<StateMachine>().ChangeState(States.Default);
    }
}
