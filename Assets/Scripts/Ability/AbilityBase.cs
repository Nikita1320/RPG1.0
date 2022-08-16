using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TypeAbility
{
    Passive,
    Active
}
public abstract class AbilityBase : MonoBehaviour
{
    [SerializeField] private string nameAbility;
    [SerializeField] private string description;
    [SerializeField] private Image icon;
    [SerializeField] private TypeAbility typeAbility;
    public string NameAbility => nameAbility;
    public string Description => description;
    public Image Icon => icon;
    public TypeAbility TypeAbility => typeAbility;

    public abstract void Begin(Character _character);
}
