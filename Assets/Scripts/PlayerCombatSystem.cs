using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatSystem : CombatSystemBase
{
    private InputController inputController;
    private AnimatorManager animatorManager;
    private Animator animator;
    
    private int countAttack = 0;
    private int currentIndexAttack = 0;

    [SerializeField] private Transform pointWeapon;
    private GameObject modelWeapon;
    private WeaponBase currentWeapon;
    private WeaponBase nextWeapon;
    public WeaponBase NextWeapon { get => nextWeapon; set { nextWeapon = value; coroutineChangeWeapon = StartCoroutine(WaitingForAChangeOfWeapons()); } }
    public WeaponBase CurrentWeapon => currentWeapon;
    private Coroutine coroutineChangeWeapon;

    private void Start()
    {
        animatorManager = GetComponent<AnimatorManager>();
        animator = GetComponent<Animator>();
        inputController = GetComponent<InputController>();
        SubscribeOnEvent();
    }

    public void SubscribeOnEvent()
    {
        inputController.attackEvent += Attack;
        inputController.exitStateEvent += ExitState;
        inputController.startStateEvent += StartState;
    }
    public override void Attack()
    {
        if (inputController.CurrentState != States.Attack)
        {
            inputController.ChangeState(States.Attack);
            animatorManager.Animator.applyRootMotion = true;
            animatorManager.Animator.SetTrigger("Attack");
        }
        countAttack++;
    }
    IEnumerator WaitingForAChangeOfWeapons()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            if (inputController.CurrentState == States.Default)
            {
                animator.SetBool("ChangeWeapon", true);
                StopCoroutine(coroutineChangeWeapon);
            }
        }
    }
    public void ChangeWeapon()
    {
        animator.SetBool("ChangeWeapon", false);
        if (currentWeapon)
        {
            currentWeapon.TakeOff();
            Destroy(modelWeapon);
        }
        currentWeapon = NextWeapon;
        if (currentWeapon)
        {
            modelWeapon = Instantiate(currentWeapon.ModelWeapon, pointWeapon);
            currentWeapon.ToClothe(gameObject);
        }
    }
    public override void GetDamage()
    {
        if (currentWeapon)
        {
            Vector3 ps2 = transform.position + (transform.forward - currentWeapon.PositionsCheckEnemy[currentIndexAttack]);
            Collider[] check = Physics.OverlapSphere(ps2, currentWeapon.RadiusCheckEnemy[currentIndexAttack]);
            foreach (var item in check)
            {
                if (item.TryGetComponent(out Health health))
                {
                    if (health != GetComponent<Health>())
                    {
                        health.ApplyDamage(new Damage(CurrentDamage, TypeDamage.Physical, gameObject, TypeSenderDamage.Weapon));
                        hitEnemyEvent(health);
                    }
                }
            }
        }
        else
        {
            Vector3 ps2 = transform.position + (transform.forward - defaultPositionsCheckEnemyRegardingTransformForfard[currentIndexAttack]);
            Collider[] check = Physics.OverlapSphere(ps2, defaultRadiusCheckEnemy[currentIndexAttack]);
            foreach (var item in check)
            {
                if (item.TryGetComponent(out Health health))
                {
                    if (health != GetComponent<Health>())
                    {
                        health.ApplyDamage(new Damage(CurrentDamage, TypeDamage.Physical, gameObject, TypeSenderDamage.Weapon));
                        hitEnemyEvent(health);
                    }
                }
            }
        }
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
            inputController.ChangeState(States.Default);
        }
    }
    public void StartState(States state)
    {

    }
    public void ExitState(States state)
    {
        if (state == States.Attack)
        {
            animatorManager.Animator.applyRootMotion = false;
            countAttack = 0;
            currentIndexAttack = 0;
        }
    }
}
