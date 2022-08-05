using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAbility: AbilityBase
{
    private Character character;
    private Coroutine timer;
    private float timeToReady;

    public float coolDown;
    public override void StartAbility(Character _character)
    {
        timer = StartCoroutine(Timer());
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
    private IEnumerator Timer()
    {
        timeToReady = coolDown;
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeToReady--;
            if (timeToReady == 0)
            {
                StopCoroutine(timer);
                canBeUsed = true;
            }
        }
    }
}
