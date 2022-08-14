using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TypeAbility
{
    Passive,
    Active
}
public class AbilityBase : MonoBehaviour
{
    public string nameAbility;
    public string discription;
    public Image image;

    public bool canBeUsed = true;
    public float coolDown;

    public AnimationClip animationClip;
    public TypeAbility typeAbility;

    public virtual void StartAbility(Character _character) { }
    public virtual void Use() { }
    public virtual void EndAbility() { }
}
