using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableSlot : ItemSlotBase
{
    private Character character;
    private int indexSlot;
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
    public void Init(Character _character, int index)
    {
        indexSlot = index;
        character = _character;
    }
}
