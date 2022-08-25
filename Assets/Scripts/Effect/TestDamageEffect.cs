using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDamageEffect : EffectBase
{
    private GameObject sender;
    private GameObject character;
    private EffectConteiner conteiner;
    private Health health;
    private Coroutine coroutine;
    private float duration = 5;
    private void Awake()
    {
        effectData = Resources.Load<EffectDataSO>("SOScript/TestEffectData");
        Debug.Log($"{effectData} in Awake");
    }
    public override void Begin(GameObject _gameObject, EffectConteiner _conteiner)
    {
        character = _gameObject;
        conteiner = _conteiner;
        health = _gameObject.GetComponent<Health>();
        coroutine = StartCoroutine(GetDamage());
    }
    IEnumerator GetDamage()
    {
        float t = duration;
        while (true)
        {
            yield return new WaitForSeconds(1f);
            health.ApplyDamage(new Damage(10, TypeDamage.Magic, gameObject, TypeSenderDamage.Effect));
            t--;
            conteiner.CoolDownImage.fillAmount = 1 - (t / duration);
            Debug.Log("damage");
            if (t <= 0)
            {
                End();
            }
        }
    }

    public override void End()
    {
        StopCoroutine(coroutine);
        Destroy(conteiner.gameObject);
        character.GetComponent<EffectsManager>().activeEffects.Remove(this);
        Destroy(this);
    }

    public override void UpdateTimeWork()
    {

    }

    public override void Init(GameObject _sender)
    {
        sender = _sender;
    }
}
