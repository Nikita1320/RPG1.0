using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeEquipment
{
    Weapon,
    Helmet,
    Armor,
    Shoes
}
public abstract class EquipmentBase : ItemBase
{
    public TypeEquipment typeEquipment;
}
