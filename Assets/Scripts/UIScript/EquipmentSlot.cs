using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSlot : ItemSlotBase
{
    private GameObject character;
    public override void AddItem(ItemBase _item)
    {
        Item = _item;
        IsEmpty = false;
    }
    public override void RemoveItem()
    {
        Item = null;
        IsEmpty = true;
    }
    public void Init(GameObject _character)
    {
        character = _character;
    }
}
