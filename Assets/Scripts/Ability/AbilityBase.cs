using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeAbility
{
    Passive,
    Active
}
public abstract class AbilityBase : MonoBehaviour
{
    [SerializeField] private string nameAbility;
    [SerializeField] private string description;
    [SerializeField] private Sprite icon;
    [SerializeField] private TypeAbility typeAbility;
    public string NameAbility => nameAbility;
    public string Description => description;
    public Sprite Icon => icon;
    public TypeAbility TypeAbility => typeAbility;

    public abstract void Begin(GameObject _character);
}
