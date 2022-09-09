using UnityEngine;

public abstract class ControllerBase<T> : MonoBehaviour
{
    public delegate void ChangeMoveSpeed(float moveSpeed);
    public ChangeMoveSpeed changeMoveSpeedEvent;

    public delegate void ChangeRotationSpeed(float moveSpeed);
    public ChangeRotationSpeed changeRotationSpeedEvent;

    [SerializeField] protected float baseMoveSpeed = 5;
    protected float valueOfChangeMoveSpeed;
    protected float �oefficientOfChangeMoveSpeed = 1;

    [SerializeField] protected float baseRotationSpeed = 0.25f;
    protected float valueOfChangeRotationSpeed;
    protected float �oefficientOfChangeRotationSpeed = 1;

    [SerializeField] public bool canBeStunned;
    public bool �anBeStunned { get => canBeStunned; }
    public float BaseMoveSpeed { get => baseMoveSpeed; protected set { } }
    public float CurrentMoveSpeed { get { return (BaseMoveSpeed + valueOfChangeMoveSpeed) * �oefficientOfChangeMoveSpeed; } }
    public float ValueOfChangeMoveSpeed { get => valueOfChangeMoveSpeed; set { valueOfChangeMoveSpeed += value; changeMoveSpeedEvent?.Invoke(CurrentMoveSpeed); } }
    public float �oefficientOfChangeMoveSpeed { get => �oefficientOfChangeMoveSpeed; set { �oefficientOfChangeMoveSpeed *= value; changeMoveSpeedEvent?.Invoke(CurrentMoveSpeed); } }

    public float BaseRotationSpeed { get => baseRotationSpeed; protected set { } }
    public float CurrentRotationSpeed { get { return (BaseRotationSpeed + valueOfChangeRotationSpeed) * �oefficientOfChangeRotationSpeed; } }
    public float ValueOfChangeRotationSpeed { get => valueOfChangeRotationSpeed; set { valueOfChangeRotationSpeed += value; changeRotationSpeedEvent?.Invoke(CurrentRotationSpeed); } }
    public float �oefficientOfChangeRotationSpeed { get => �oefficientOfChangeRotationSpeed; set { �oefficientOfChangeRotationSpeed *= value; changeRotationSpeedEvent?.Invoke(CurrentRotationSpeed); } }
    public abstract void Move(T direction);
    public abstract void Rotate(Vector2 direction);
    public abstract void EntryStun();
    public abstract void ExitStun();
}
