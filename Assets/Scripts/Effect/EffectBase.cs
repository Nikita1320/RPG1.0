using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectBase : MonoBehaviour
{
    [SerializeField] protected string pathOnData;
    [SerializeField] protected EffectDataSO effectData;

    public EffectDataSO EffectData => effectData;
    public abstract void Init(GameObject sender);
    public abstract void Begin(GameObject _gameObject, EffectConteiner conteiner);

    public abstract void UpdateTimeWork();

    public abstract void End();
    public IEnumerator Timer()
    {
        yield return new WaitForEndOfFrame();
    }
}
