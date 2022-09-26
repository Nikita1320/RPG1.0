using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIStateBase<T>
{
    public abstract void Begin();
    public abstract void Exit();
    public abstract void Init(T _inputActionsUI);
}
