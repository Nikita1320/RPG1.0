using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRotate
{
    public float CurrentRotationSpeed { get; }
    public float ValueOfChangeRotationSpeed { set; }
    public float �oefficientOfChangeRotationSpeed { set; }
    public void Rotate() { }
}
