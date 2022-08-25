using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableSlot : ItemSlotBase
{
    private GameObject character;
    private int indexSlot;
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
    public void Init(GameObject _character, int index)
    {
        indexSlot = index;
        character = _character;
    }
}
