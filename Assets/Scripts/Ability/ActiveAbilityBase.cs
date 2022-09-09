using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActiveAbilityBase : AbilityBase
{
    public delegate void StartCoolDownTimer();
    public delegate void TickCoolDownTimer(float amountFillValue);
    public delegate void EndCoolDownTimer();
    public StartCoolDownTimer startCoolDownTimerEvent;
    public TickCoolDownTimer tickCoolDownTimerEvent;
    public EndCoolDownTimer endCoolDownTimerEvent;

    [SerializeField] private float coolDown;
    [SerializeField] private AnimationClip animationClip;

    private bool isReadyToUse = true;

    protected Coroutine timerCoroutine;
    public AnimationClip Animation => animationClip;
    public float CoolDown => coolDown;
    public bool IsReadyToUse => isReadyToUse;
    public abstract void Use();

    protected IEnumerator CoolDownTimer()
    {
        startCoolDownTimerEvent();
        isReadyToUse = false;
        float t = coolDown;
        float tickAmountValue = 1 / t;
        while (true)
        {
            yield return new WaitForSeconds(1);
            t--;
            tickCoolDownTimerEvent(tickAmountValue);
            if (t <= 0)
            {
                endCoolDownTimerEvent();
                isReadyToUse = true;
                StopCoroutine(timerCoroutine);
            }
            
        }
    }
}
