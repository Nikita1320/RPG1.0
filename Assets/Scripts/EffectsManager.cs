using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    public delegate void ChangeResistanceToEffects(float resistanceToEffects);
    public ChangeResistanceToEffects changeResistanceToEffectsEvent;

    public List<EffectBase> activeEffects;
    public List<EffectBase> passiveEffects;

    [SerializeField] private GameObject effectConteiner;
    [SerializeField] private GameObject effectPanel;

    [SerializeField] private float baseResistanceToEffects;
    private float ñoefficientOfChangeResistanceToEffects = 1;

    public float CurrentResistanceToEffects { get { return baseResistanceToEffects * ÑoefficientOfChangeResistanceToEffects; } }
    public float ÑoefficientOfChangeResistanceToEffects { private get { return ñoefficientOfChangeResistanceToEffects; } set { ñoefficientOfChangeResistanceToEffects *= value; changeResistanceToEffectsEvent(CurrentResistanceToEffects); } }
    public void AddEffect(EffectBase effect)
    {
        GameObject newConteiner = Instantiate(effectConteiner, effectPanel.transform);

        newConteiner.GetComponent<EffectConteiner>().Init(effect.EffectData.Icon);
        newConteiner.GetComponent<UIDescriptionEffect>().Init(effect);

        if (effect.EffectData.TypeLifeCycle == TypeLifeCycleEffect.Passive)
        {
            passiveEffects.Add(effect);
            newConteiner.transform.SetSiblingIndex(passiveEffects.Count);
            effect.Begin(gameObject,newConteiner.GetComponent<EffectConteiner>());
        }
        else
        {
            activeEffects.Add(effect);
            effect.Begin(gameObject, newConteiner.GetComponent<EffectConteiner>());
        }
    }

    public void ResetEffects(TypeInfluenceEffect typeEffect)
    {
        foreach (var effect in activeEffects)
        {
            if (effect.EffectData.TypeInfluence == typeEffect && effect.EffectData.CanBeRemoved)
            {
                effect.End();
                activeEffects.Remove(effect);
            }
        }
    }
}
