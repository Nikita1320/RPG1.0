using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlot : ItemSlotBase
{
    private Character character;
    public override void AddItem(ItemBase _item)
    {
        Item = _item;
        Item.currentSlot = this;
        IsEmpty = false;
    }
    public override void RemoveItem()
    {
        Item = null;
        IsEmpty = true;
    }
    public void Init(Character _character)
    {
        character = _character;
    }
}
