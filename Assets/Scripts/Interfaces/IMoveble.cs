using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveble<T>
{
    public float CurrentMoveSpeed { get; }
    public float ValueOfChangeMoveSpeed { set; }
    public float �oefficientOfChangeMoveSpeed { set; }
    public void Move(T _direction)
    {

    }
}
