using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogEffect : BaseEffect
{
    public GameObject go;
    public Coroutine coroutine;
    public float Damage = 0;
    public override void Begin(GameObject _gameObject)
    {
        go = _gameObject;
        Debug.Log($"Start for {go.name}");
        coroutine = StartCoroutine(Tick());
    }

    IEnumerator Tick()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Damage++;
            Debug.Log($"Damage for {go.name} = {Damage}");
        }
    }

    public override void End()
    {
        Debug.Log($"Exit for {go.name}");
        StopCoroutine(coroutine);
    }

    public override void UpdateTimeWork()
    {
        throw new System.NotImplementedException();
    }
}
