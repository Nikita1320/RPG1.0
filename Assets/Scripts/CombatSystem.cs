using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    public GameObject test;
    public delegate void HitEnemy(Health enemy);
    public delegate void ChangeDamage(float damage);
    public delegate void CausedDamage(Damage Damage);

    public HitEnemy hitEnemyEvent;
    public ChangeDamage changeDamageEvent;
    public CausedDamage causedDamageEvent;

    private StateMachine stateMachine;
    private AnimatorManager animatorManager;

    [SerializeField] private float baseDamage = 10;
    private float valueOfChangeDamage;
    private float ñoefficientOfChangeDamage = 1;

    [SerializeField] private float[] defaultCoefficientPosition;
    [SerializeField] private Vector3[] defaultPositionsCheckEnemy;
    [SerializeField] private float[] defaultRadiusCheckEnemy;
    
    public int countAttack = 0;
    public int currentIndexAttack = 0;
    private WeaponBase currentWeapon;
    private WeaponBase nextWeapon;

    private Health[] hitEnemy;

    public float CurrentDamage { get { return (baseDamage + ValueOfChangeDamage) * ÑoefficientOfChangeDamage; } }
    public float ValueOfChangeDamage { private get { return valueOfChangeDamage; } set { valueOfChangeDamage += value; changeDamageEvent(CurrentDamage); } }
    public float ÑoefficientOfChangeDamage { private get { return ñoefficientOfChangeDamage; } set { ñoefficientOfChangeDamage *= value; changeDamageEvent(CurrentDamage); } }

    private void Start()
    {
        animatorManager = GetComponent<AnimatorManager>();
        stateMachine = GetComponent<StateMachine>();
        SubscribeOnEvent();
    }

    public void SubscribeOnEvent()
    {
        stateMachine.attackEvent += Attack;
        stateMachine.exitStateEvent += ExitState;
        stateMachine.startStateEvent += StartState;
    }
    public void Attack()
    {
        if (stateMachine.currentState != States.Attack)
        {
            stateMachine.ChangeState(States.Attack);
            animatorManager.Animator.applyRootMotion = true;
            animatorManager.Animator.SetTrigger("Attack");
        }
        countAttack++;
    }
    public void ExitState(States state)
    {
        if (state == States.Attack)
        {
            animatorManager.Animator.applyRootMotion = true;
            countAttack = 0;
            currentIndexAttack = 0;
        }
    }
    public void StartState(States state)
    {
        
    }
    public void ChangeWeapn()
    {

    }
    public void GetDamage()
    {
        if (currentWeapon)
        {
            Vector3 pos = transform.position;
            Vector3 ps = Vector3.forward;
            Vector3 ps2 = new Vector3(ps.x * defaultCoefficientPosition[0], ps.y, ps.z * defaultCoefficientPosition[0]);
            Collider[] check = Physics.OverlapSphere(ps2, defaultRadiusCheckEnemy[0]);
            foreach (var item in check)
            {
                if (item.TryGetComponent<Health>(out Health health))
                {
                    health.ApplyDamage(new Damage(CurrentDamage, TypeDamage.Physical, gameObject, TypeSenderDamage.Weapon));
                }
            }
        }
        else
        {
            Vector3 ps = Vector3.forward;
            Vector3 ps2 = transform.position + transform.forward;
            //GameObject go = Instantiate(test);
            //go.transform.position = ps2;
            Collider[] check = Physics.OverlapSphere(ps2, defaultRadiusCheckEnemy[0]);
            foreach (var item in check)
            {
                if (item.TryGetComponent<Health>(out Health health))
                {
                    if (health != GetComponent<Health>())
                    {
                        health.ApplyDamage(new Damage(CurrentDamage, TypeDamage.Physical, gameObject, TypeSenderDamage.Weapon));
                    }
                }
            }
        }
        //GetComponent<Health>();
        //Îòïðàâëÿþ óðîí
    }
    public void CheckCountAttack()
    {
        currentIndexAttack++;
        if (countAttack > currentIndexAttack)
        {
            animatorManager.Animator.SetInteger("AttackCount", currentIndexAttack);
        }
        else
        {
            animatorManager.Animator.SetInteger("AttackCount", 0);
            stateMachine.ChangeState(States.Default);
        }
    }
}
