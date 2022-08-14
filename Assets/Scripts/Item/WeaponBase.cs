using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : ItemBase
{
    public AnimationClip[] animationClips;
    public Vector3[] positionsCheckEnemy;
    public float[] radiusCheckEnemy;
}
