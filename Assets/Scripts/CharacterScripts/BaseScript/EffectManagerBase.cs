using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectManagerBase : MonoBehaviour
{
    public List<EffectBase> activeEffects;
    public List<EffectBase> passiveEffects;

    public bool immunityToEffect = false;

    [SerializeField] protected float baseResistanceToEffects;
    [SerializeField] protected float �oefficientOfChangeResistanceToEffects = 1;

    public abstract float CurrentResistanceToEffects { get; }
    public abstract float �oefficientOfChangeResistanceToEffects { get; set; }
    public abstract void AddEffect(EffectBase effect);
    public abstract void ResetEffects(TypeInfluenceEffect typeEffect);
}
