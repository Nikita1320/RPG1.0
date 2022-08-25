using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGetEffect : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        EffectBase e = collision.gameObject.AddComponent<TestDamageEffect>();
        e.Init(gameObject);
        collision.gameObject.GetComponent<EffectsManager>().AddEffect(e);
    }
}
