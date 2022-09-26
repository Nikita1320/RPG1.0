using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityManagerBase : MonoBehaviour
{
    public delegate void ChangeCooldownReduction(float CooldownReduction);
    public ChangeCooldownReduction changeCooldownReductionEvent;

    [SerializeField] protected float baseCooldownReduction = 1;
    protected float ñoefficientOfChangeCooldownReduction = 1;

    public float CurrentCooldownReduction { get { return baseCooldownReduction * ÑoefficientOfChangeCooldownReduction; } }
    public float ÑoefficientOfChangeCooldownReduction { private get { return ñoefficientOfChangeCooldownReduction; } set { ñoefficientOfChangeCooldownReduction *= value; changeCooldownReductionEvent(CurrentCooldownReduction); } }

    public abstract void StartAbility(int index);
    public abstract void AnimationEvent();
    public abstract void EndAbility();

    protected abstract void InitSlot();
}
