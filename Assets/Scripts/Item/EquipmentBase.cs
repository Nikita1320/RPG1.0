using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class EquipmentBase : ItemBase
{
    public abstract void ToClothe(GameObject character);
    public abstract void TakeOff();
}
