using UnityEngine;

public class PlayerEffectsManager : EffectManagerBase
{
    public delegate void ChangeResistanceToEffects(float resistanceToEffects);
    public ChangeResistanceToEffects changeResistanceToEffectsEvent;

    [SerializeField] private GameObject effectConteiner;
    [SerializeField] private GameObject effectPanel;
    public override float CurrentResistanceToEffects { get { return baseResistanceToEffects * ÑoefficientOfChangeResistanceToEffects; } }
    public override float ÑoefficientOfChangeResistanceToEffects { get { return ñoefficientOfChangeResistanceToEffects; } set { ñoefficientOfChangeResistanceToEffects *= value; changeResistanceToEffectsEvent(CurrentResistanceToEffects); } }
    
    public override void AddEffect(EffectBase effect)
    {
        GameObject newConteiner = Instantiate(effectConteiner, effectPanel.transform);

        newConteiner.GetComponent<EffectConteiner>().Init(effect);
        newConteiner.GetComponent<UIDescriptionEffect>().Init(effect);

        if (effect.EffectData.TypeLifeCycle == TypeLifeCycleEffect.Passive)
        {
            passiveEffects.Add(effect);
            effect.Begin(gameObject);
            newConteiner.transform.SetSiblingIndex(passiveEffects.Count);
        }
        else
        {
            activeEffects.Add(effect);
            effect.Begin(gameObject);
        }
    }

    public override void ResetEffects(TypeInfluenceEffect typeEffect)
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
