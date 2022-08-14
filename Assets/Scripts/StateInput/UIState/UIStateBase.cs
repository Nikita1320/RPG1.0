using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIStateBase
{
    public abstract void Begin();
    public abstract void Exit();
    public abstract void Init(UIStateMachine uiStateMachine);
}
