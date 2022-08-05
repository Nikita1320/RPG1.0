using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeEffect : MonoBehaviour
{
    public BaseEffect effect;
    public List<BaseEffect> effects;
    public void AddEffect(BaseEffect _effect)
    {
        effect = _effect;
        effect.Begin(gameObject);
    }
    public void RemoveEffect()
    {
        effect.End();
        effect = null;
    }
    public void LogType()
    {
        Debug.Log(effects[0].GetType());
    }
}
