using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public delegate void ChangeMoveSpeed(float moveSpeed);
    public ChangeMoveSpeed changeMoveSpeedEvent;

    public Rigidbody rb;
    private CapsuleCollider capsuleCollider;
    private AnimatorManager animatorManager;
    private StateMachine stateMachine;

    [SerializeField] private float baseMoveSpeed = 5;
    private float valueOfChangeMoveSpeed;
    private float ñoefficientOfChangeMoveSpeed = 1;

    [SerializeField] private float baseJumpPower = 5;
    [SerializeField] private float baseJerkPower = 1;
    public bool IsGrounded
    {
        get
        {
            Vector3 bottomCenterPoint = new Vector3(capsuleCollider.bounds.center.x, capsuleCollider.bounds.min.y, capsuleCollider.bounds.center.z);
            return Physics.CheckSphere(bottomCenterPoint, 0.15f, 1);
        }
    }
    public float CurrentMoveSpeed { get { return (baseMoveSpeed + ValueOfChangeMoveSpeed) * ÑoefficientOfChangeMoveSpeed; } }
    public float ValueOfChangeMoveSpeed { private get { return valueOfChangeMoveSpeed; } set { valueOfChangeMoveSpeed += value; changeMoveSpeedEvent(CurrentMoveSpeed); } }
    public float ÑoefficientOfChangeMoveSpeed { private get { return ñoefficientOfChangeMoveSpeed; } set { ñoefficientOfChangeMoveSpeed *= value; changeMoveSpeedEvent(CurrentMoveSpeed); } }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        stateMachine = GetComponent<StateMachine>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        animatorManager = GetComponent<AnimatorManager>();
        stateMachine.startStateEvent += StartState;
        stateMachine.exitStateEvent += ExitState;
    }

    private void Start()
    {
        SubscribeOnEvent();
    }

    private void Update()
    {
        if (!IsGrounded)
        {
            if (stateMachine.currentState == States.Default)
            {
                stateMachine.ChangeState(States.InAir);
                animatorManager.Animator.SetBool("InAir", true);
            }
        }
        else
        {
            if (stateMachine.currentState == States.InAir)
            {
                Debug.Log("Transit in DefaultUpdate");
                stateMachine.ChangeState(States.Default);
                animatorManager.Animator.SetBool("InAir", false);
            }
        }
    }

    public void Move(Vector2 direction)
    {
        Vector2 moveDir = direction * CurrentMoveSpeed;
        if (direction != Vector2.zero)
        {
            rb.velocity = new Vector3(moveDir.x, rb.velocity.y, moveDir.y);
            animatorManager.Animator.SetBool("Run", true);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(moveDir.x, 0, moveDir.y)), 0.25f);
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            animatorManager.Animator.SetBool("Run", false);
        }
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * baseJumpPower, ForceMode.Impulse);
        animatorManager.Animator.SetTrigger("Jump");
    }

    public void Jerk()
    {
        Vector3 directionJerk = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        if (directionJerk != Vector3.zero)
        {
            stateMachine.ChangeState(States.Disable);
            rb.AddForce(directionJerk * baseJerkPower, ForceMode.Impulse);
            Debug.Log(directionJerk);
            animatorManager.Animator.SetTrigger("Jerk");
        }
    }
    public void ExitJerk()
    {
        stateMachine.ChangeState(States.Default);
    }

    public void BeginBlock()
    {
        stateMachine.ChangeState(States.Block);
        animatorManager.Animator.SetBool("Block", true);
    }

    public void ExitBlock()
    {
        animatorManager.Animator.SetBool("Block", false);
        stateMachine.ChangeState(States.Default);
    }

    public void ExitState(States _state)
    {

    }
    public void StartState(States _state)
    {

    }

    public void SubscribeOnEvent()
    {
        stateMachine.jumpEvent += Jump;
        stateMachine.jerkEvent += Jerk;
        stateMachine.blockEvent += BeginBlock;
        stateMachine.exitBlockEvent += ExitBlock;
        stateMachine.moveEvent += Move;
    }
}
