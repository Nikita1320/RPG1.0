using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStateInput<T,K>
{
    public abstract void Begin();
    public abstract void Exit(K state);
    public abstract void Init(T _inputActions);
}
