using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeDamage
{
    Physical,
    Magic
}

public enum TypeSenderDamage
{
    Weapon,
    Ability,
    Effect
}
public struct Damage
{
    private float damage;
    private TypeDamage typeDamage;
    private GameObject sender;
    private TypeSenderDamage typeSenderDamage;
    public float AmountDamage => damage;
    public TypeDamage TypeDamage => typeDamage;
    public Object Sender => sender;
    public TypeSenderDamage TypeSenderDamage => typeSenderDamage;
    public Damage(float _damage, TypeDamage _typeDamage, GameObject _sender, TypeSenderDamage _typeSenderDamage)
    {
        damage = _damage;
        typeDamage = _typeDamage;
        sender = _sender;
        typeSenderDamage = _typeSenderDamage;
    }
}
public class Health : MonoBehaviour
{
    public delegate void ChangeCurrentHealth(float value);
    public delegate void ChangeMaxHealth(float value);
    public delegate void ChangeCurrentArmor(float value);
    public delegate void ChangeMagicResistance(float value);
    public delegate Damage TakeDamage(Damage Damage);

    public ChangeCurrentHealth changeCurrentHealthEvent;
    public ChangeMaxHealth changeMaxHealthEvent;
    public ChangeCurrentArmor changeCurrentArmorEvent;
    public ChangeMagicResistance changeMagicResistanceEvent;
    public TakeDamage takeDamageEvent;

    [SerializeField] private float baseHealth;
    private float valueOfChangeHealth;
    private float ñoefficientOfChangeHealth = 1;

    [SerializeField] private float baseArmor;
    private float valueOfChangeArmor;
    private float ñoefficientOfChangeArmor = 1;

    [SerializeField] private float baseMagicResistance;
    private float valueOfChangeMagicResistancer;
    private float ñoefficientOfChangeMagicResistance = 1;

    public float curhel;
    public float CurrentHealth { get; private set; }
    public float MaxHealth { get { return (baseHealth + ValueOfChangeHealth) * ÑoefficientOfChangeHealth; } }
    public float ValueOfChangeHealth { private get { return valueOfChangeHealth; } set { RecalculationHealthWithCoefficient(value); valueOfChangeHealth += value; } }
    public float ÑoefficientOfChangeHealth { private get { return ñoefficientOfChangeHealth; } set { RecalculationHealthWithValue(value); ñoefficientOfChangeHealth *= value; } }

    public float CurrentArmor { get { return (baseArmor + ValueOfChangeHealth) * ÑoefficientOfChangeHealth; } }
    public float ValueOfChangeArmor { private get { return valueOfChangeArmor; } set { valueOfChangeArmor += value; changeCurrentArmorEvent(CurrentArmor); } }
    public float ÑoefficientOfChangeArmor { private get { return ñoefficientOfChangeArmor; } set { ñoefficientOfChangeArmor *= value; changeCurrentArmorEvent(CurrentArmor); } }

    public float CurrentMagicResistance { get { return (baseMagicResistance + ValueOfChangeMagicResistance) * ÑoefficientOfChangeMagicResistance; } }
    public float ValueOfChangeMagicResistance { private get { return valueOfChangeMagicResistancer; } set { valueOfChangeMagicResistancer += value; changeMagicResistanceEvent(CurrentMagicResistance); } }
    public float ÑoefficientOfChangeMagicResistance { private get { return ñoefficientOfChangeMagicResistance; } set { ñoefficientOfChangeMagicResistance *= value; changeMagicResistanceEvent(CurrentMagicResistance); } }
    private void Start()
    {
        CurrentHealth = MaxHealth;
        curhel = CurrentHealth;
    }
    public void ApplyDamage(Damage damage)//(int damage, TypeDamage typeDamage)
    {
        Damage totalDamage = damage;
        if (takeDamageEvent != null)
        {
            totalDamage = takeDamageEvent(damage);
        }

        if (damage.TypeDamage == TypeDamage.Physical)
        {
            CurrentHealth -= (totalDamage.AmountDamage - CurrentArmor);
        }
        else
        {
            CurrentHealth -= (totalDamage.AmountDamage - CurrentMagicResistance);
        }

        if (TryGetComponent(out CombatSystem combatSystem))
        {
            combatSystem.causedDamageEvent?.Invoke(totalDamage);
        }
        curhel = CurrentHealth;
        if (CurrentHealth <= 0)
        {
            Death();
        }
        changeCurrentHealthEvent?.Invoke(CurrentHealth);
    }
    public void Heal(float healValue)
    {
        CurrentHealth += healValue;
        if (CurrentHealth >= MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
        changeCurrentHealthEvent(CurrentHealth);
    }
    public void Death()
    {
        Destroy(gameObject);
    }
    private void RecalculationHealthWithCoefficient(float coefficient)
    {
        CurrentHealth *= coefficient;
        changeMaxHealthEvent(MaxHealth);
        changeCurrentHealthEvent(CurrentHealth);
    }
    private void RecalculationHealthWithValue(float value)
    {
        float percentOfMax = CurrentHealth / MaxHealth;
        CurrentHealth += value * percentOfMax;
        changeMaxHealthEvent(MaxHealth);
        changeCurrentHealthEvent(CurrentHealth);
    }
}
