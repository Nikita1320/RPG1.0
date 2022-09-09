using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestAbility: ActiveAbilityBase
{
    [SerializeField] float damage;
    [SerializeField] TypeDamage typeDamage;
    private GameObject character;
    public override void Begin(GameObject _character)
    {
        character = _character;
        timerCoroutine = StartCoroutine(CoolDownTimer());
    }
    public override void Use() 
    {
        Vector3 ps2 = character.transform.position + character.transform.forward;
        Collider[] check = Physics.OverlapSphere(ps2, 1);
        foreach (var item in check)
        {
            if (item.TryGetComponent<Health>(out Health health))
            {
                if (health != character.GetComponent<Health>())
                {
                    health.ApplyDamage(new Damage(damage, typeDamage, character, TypeSenderDamage.Ability));
                }
            }
        }
    }
}
