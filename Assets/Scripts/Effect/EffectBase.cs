using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectBase : MonoBehaviour
{
    public delegate void Tick(float value);
    public Tick tickEvent;
    public delegate void EndEffect();
    public EndEffect endEffectEvent;
    [SerializeField] protected string pathOnData;
    [SerializeField] protected EffectDataSO effectData;

    public EffectDataSO EffectData => effectData;
    public abstract void Init(GameObject sender);
    public abstract void Begin(GameObject _gameObject);
    protected IEnumerator Timer(float timeTick)
    {
        while (true)
        {
            yield return new WaitForSeconds(timeTick);
            Use();
        }
    }
    public abstract void Use();

    public abstract void UpdateTimeWork();

    public abstract void End();
}
