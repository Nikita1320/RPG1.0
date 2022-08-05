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

    public bool canBeUsed;

    public AnimationClip animationClip;
    public TypeAbility typeAbility;

    private Character character;

    public virtual void StartAbility(Character _character) { }
    public virtual void Use() { }
    public virtual void EndAbility() { }
}
