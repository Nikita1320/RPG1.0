using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeEffect
{
    Positive,
    Negative
}
public abstract class BaseEffect : MonoBehaviour
{
    public TypeEffect typeEffect;
    public bool canBeDeleted;
    public abstract void Begin(GameObject _gameObject);

    public abstract void UpdateTimeWork();

    public abstract void End();
}
