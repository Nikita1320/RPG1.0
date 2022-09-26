using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CombatSystemBase : MonoBehaviour
{
    public delegate void HitEnemy(Health enemy);
    public delegate void ChangeDamage(float damage);
    public delegate void CausedDamage(Damage Damage);

    public HitEnemy hitEnemyEvent;
    public ChangeDamage changeDamageEvent;
    public CausedDamage causedDamageEvent;

    [SerializeField] protected float baseDamage = 10;
    protected float valueOfChangeDamage;
    protected float �oefficientOfChangeDamage = 1;

    [SerializeField] protected Vector3[] defaultPositionsCheckEnemyRegardingTransformForfard;
    [SerializeField] protected float[] defaultRadiusCheckEnemy;

    public float CurrentDamage { get { return (baseDamage + ValueOfChangeDamage) * �oefficientOfChangeDamage; } }
    public float ValueOfChangeDamage { private get { return valueOfChangeDamage; } set { valueOfChangeDamage += value; changeDamageEvent(CurrentDamage); } }
    public float �oefficientOfChangeDamage { private get { return �oefficientOfChangeDamage; } set { �oefficientOfChangeDamage *= value; changeDamageEvent(CurrentDamage); } }
    public abstract void Attack();
    public abstract void GetDamage();
}
