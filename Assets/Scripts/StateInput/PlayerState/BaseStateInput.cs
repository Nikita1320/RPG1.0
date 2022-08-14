using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStateInput
{
    public abstract void Begin();
    public abstract void Exit();
    public abstract void Init(InputController _inputController);
}