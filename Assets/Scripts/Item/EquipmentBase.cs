using UnityEngine;


public abstract class EquipmentBase : ItemBase
{
    [SerializeField] private GameObject modelEquipment;
    public GameObject ModelEquipment => modelEquipment;
    public abstract void ToClothe(GameObject character);
    public abstract void TakeOff();
}
