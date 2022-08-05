using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    public List<BaseEffect> effects;

    public void AddEffect(BaseEffect effect, bool characterHaveThisEffect)
    {
        if (characterHaveThisEffect)
        {
            foreach (var efct in effects)
            {
                if (efct == effect)
                {
                    effect.UpdateTimeWork();
                }
            }
        }
        else
        {
            effect.Begin(gameObject);
            effects.Add(effect);
        }
    }

    public void ResetEffects(TypeEffect typeEffect)
    {
        foreach (var efct in effects)
        {
            if (efct.typeEffect == typeEffect && efct.canBeDeleted)
            {
                efct.End();
                Destroy(efct);
            }
        }
    }
}
