using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActiveAbilityBase : AbilityBase
{
    [SerializeField] private float coolDown;
    [SerializeField] private AnimationClip animationClip;
    public AnimationClip Animation => animationClip;
    public float CoolDown => coolDown;
    public abstract void Use();
}
