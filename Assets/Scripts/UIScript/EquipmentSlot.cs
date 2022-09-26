using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSlot : ItemSlotBase
{
    private GameObject character;
    private EquipmentBase equipmentItem;
    public override void AddItem(ItemBase _item)
    {
        equipmentItem = (EquipmentBase)_item;
        Item = _item;
        IsEmpty = false;
        equipmentItem.ToClothe(character);
    }
    public override void RemoveItem()
    {
        Item = null;
        IsEmpty = true;
        equipmentItem.TakeOff();
    }
    public void Init(GameObject _character)
    {
        character = _character;
    }
}
