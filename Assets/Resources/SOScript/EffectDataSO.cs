using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeInfluenceEffect
{
    Positive,
    Negative
}
public enum TypeLifeCycleEffect
{
    Active,
    Passive
}
[CreateAssetMenu(fileName = "EffectData", menuName = "ScriptableObjects/EffectData", order = 1)]
public class EffectDataSO : ScriptableObject
{
    [SerializeField] private string nameEffect;
    [SerializeField] private string description;
    [SerializeField] private Sprite icon;
    [SerializeField] private TypeInfluenceEffect typeInfluence;
    [SerializeField] private TypeLifeCycleEffect typeLifeCycle;
    [SerializeField] private bool canBeRemoved;
    [SerializeField] private bool superimposedThroughImmunityToEffect;

    public string NameEffect => nameEffect;
    public string Description => description;
    public Sprite Icon => icon;
    public TypeInfluenceEffect TypeInfluence => typeInfluence;
    public TypeLifeCycleEffect TypeLifeCycle => typeLifeCycle;
    public bool CanBeRemoved => canBeRemoved;
    public bool SuperimposedThroughImmunityToEffect => superimposedThroughImmunityToEffect;
}
