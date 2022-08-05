using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEffect : MonoBehaviour
{
    public BaseEffect effect;

    private void Start()
    {
        effect = new LogEffect();
    }
    public void OnCollisionEnter(UnityEngine.Collision collision)
    {
        collision.gameObject.GetComponent<TakeEffect>().effects.Add(collision.gameObject.AddComponent<LogEffect>());
        collision.gameObject.GetComponent<TakeEffect>().LogType();
    }
    public void OnCollisionExit(UnityEngine.Collision collision)
    {

    }
}
