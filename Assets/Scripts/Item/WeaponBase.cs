using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : ItemBase
{
    [SerializeField] private AnimationClip[] animationClips;
    [SerializeField] private Vector3[] positionsCheckEnemy;
    [SerializeField] private float[] radiusCheckEnemy;
    public AnimationClip[] AnimationClips => animationClips;
    public Vector3[] PositionsCheckEnemy => positionsCheckEnemy;
    public float[] RadiusCheckEnemy => radiusCheckEnemy;

    public abstract void ToClothe(GameObject character);
    public abstract void TakeOff();
}
