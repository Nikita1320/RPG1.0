using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDamageEffect : EffectBase
{
    private GameObject sender;
    private GameObject character;
    private Health health;
    private Coroutine coroutine;
    private float timeTick = 1;
    private float duration = 5;
    private float remained;
    public override void Init(GameObject _sender)
    {
        sender = _sender;
        effectData = Resources.Load<EffectDataSO>("SOScript/TestEffectData");
    }
    public override void Begin(GameObject _gameObject)
    {
        character = _gameObject;
        health = _gameObject.GetComponent<Health>();
        coroutine = StartCoroutine(Timer(timeTick));
        remained = duration;
    }
    public override void Use()
    {
        health.ApplyDamage(new Damage(10, TypeDamage.Magic, sender, TypeSenderDamage.Effect));
        remained--;
        tickEvent?.Invoke(1 - (remained / duration));
        Debug.Log("damage");
        if (remained <= 0)
        {
            End();
        }
    }

    public override void End()
    {
        StopCoroutine(coroutine);
        endEffectEvent?.Invoke();
        GetComponent<PlayerEffectsManager>().activeEffects.Remove(this);
        Destroy(this);
    }
    

    public override void UpdateTimeWork()
    {

    }
}
