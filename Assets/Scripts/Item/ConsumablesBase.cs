using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConsumablesBase : ItemBase
{
    public int currentCount;
    public AnimationClip animationClip;

    [SerializeField] private int maxCount;

    public abstract void Use();
}
