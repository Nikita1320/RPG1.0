using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatSystem : CombatSystemBase
{
    [SerializeField] private float rangeAttack;
    public float RangeAttack => rangeAttack;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public override void Attack()
    {
        animator.SetTrigger("Attack");
    }

    public override void GetDamage()
    {
        Vector3 pointAttack = transform.position + transform.forward;
        Collider[] check = Physics.OverlapSphere(pointAttack, 1);
        foreach (var item in check)
        {
            if (item.gameObject.CompareTag("Player"))
            {
                if (item.TryGetComponent(out Health health))
                {
                    health.ApplyDamage(new Damage(CurrentDamage, TypeDamage.Physical, gameObject, TypeSenderDamage.Weapon));
                    hitEnemyEvent?.Invoke(health);
                }
            }
        }
    }
}
