using UnityEngine;

public abstract class WeaponBase : ItemBase
{
    [SerializeField] private GameObject modelWeapon;
    [SerializeField] private AnimationClip[] animationClips;
    [SerializeField] private Vector3[] positionsCheckEnemyRegardingTransformForfard;
    [SerializeField] private float[] radiusCheckEnemy;
    public GameObject ModelWeapon => modelWeapon;
    public AnimationClip[] AnimationClips => animationClips;
    public Vector3[] PositionsCheckEnemy => positionsCheckEnemyRegardingTransformForfard;
    public float[] RadiusCheckEnemy => radiusCheckEnemy;

    public abstract void ToClothe(GameObject character);
    public abstract void TakeOff();
}
