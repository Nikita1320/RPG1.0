using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    public string nameItem;
    public string description;

    public abstract void ToClothe(Character character);
    public abstract void TakeOff();
}
