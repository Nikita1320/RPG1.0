using UnityEngine;

public abstract class ConsumablesBase : ItemBase
{
    [SerializeField] private int maxCount;
    [SerializeField] private int currentCount;

    public int MaxCount => maxCount;
    public int CurrentCount { get => currentCount; set { currentCount += value; } }

    public abstract void ToClothe(GameObject character);
    public abstract void TakeOff();
    public abstract void Use();
}
