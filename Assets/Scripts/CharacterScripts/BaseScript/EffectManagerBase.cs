using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectManagerBase : MonoBehaviour
{
    public List<EffectBase> activeEffects;
    public List<EffectBase> passiveEffects;

    public bool immunityToEffect = false;

    [SerializeField] protected float baseResistanceToEffects;
    [SerializeField] protected float ñoefficientOfChangeResistanceToEffects = 1;

    public abstract float CurrentResistanceToEffects { get; }
    public abstract float ÑoefficientOfChangeResistanceToEffects { get; set; }
    public abstract void AddEffect(EffectBase effect);
    public abstract void ResetEffects(TypeInfluenceEffect typeEffect);
}
