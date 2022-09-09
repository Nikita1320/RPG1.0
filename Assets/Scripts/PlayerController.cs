using UnityEngine;


public class PlayerController : ControllerBase<Vector2>
{
    private Rigidbody rb;
    private CapsuleCollider capsuleCollider;
    private Animator animator;
    private InputController inputController;
    private Health health;

    [SerializeField] private float baseJumpPower = 5;
    [SerializeField] private float baseJerkPower = 1;

    private bool inBlock = false;
    public bool IsGrounded
    {
        get
        {
            Vector3 bottomCenterPoint = new Vector3(capsuleCollider.bounds.center.x, capsuleCollider.bounds.min.y, capsuleCollider.bounds.center.z);
            return Physics.CheckSphere(bottomCenterPoint, 0.15f, 1);
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        inputController = GetComponent<InputController>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
    }

    private void Start()
    {
        SubscribeOnEvent();
    }

    private void Update()
    {
        if (!IsGrounded)
        {
            if (inputController.CurrentState == States.Default)
            {
                inputController.ChangeState(States.InAir);
                animator.SetBool("InAir", true);
            }
        }
        else
        {
            if (inputController.CurrentState == States.InAir)
            {
                Debug.Log("Transit in DefaultUpdate");
                inputController.ChangeState(States.Default);
                animator.SetBool("InAir", false);
            }
        }
    }

    public override void Move(Vector2 direction)
    {
        Vector2 moveDir = direction * CurrentMoveSpeed;
        if (direction != Vector2.zero)
        {
            rb.velocity = new Vector3(moveDir.x, rb.velocity.y, moveDir.y);
            animator.SetBool("Run", true);
            Rotate(moveDir);
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            animator.SetBool("Run", false);
        }
    }
    public override void Rotate(Vector2 direction)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(direction.x, 0, direction.y)), CurrentRotationSpeed);
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * baseJumpPower, ForceMode.Impulse);
        animator.SetTrigger("Jump");
    }

    private void Jerk()
    {
        Vector3 directionJerk = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        if (directionJerk != Vector3.zero)
        {
            inputController.ChangeState(States.Disable);
            rb.AddForce(directionJerk * baseJerkPower, ForceMode.Impulse);
            Debug.Log(directionJerk);
            animator.SetTrigger("Jerk");
        }
    }
    public void ExitJerk()
    {
        inputController.ChangeState(States.Default);
    }

    private void BeginBlock()
    {
        inputController.ChangeState(States.Block);
        Block(true);
        animator.SetBool("Block", true);
    }

    private void ExitBlock()
    {
        animator.SetBool("Block", false);
        Block(false);
        inputController.ChangeState(States.Default);
    }
    private void Block(bool isEntryBlock)
    {
        if (isEntryBlock)
        {
            canBeStunned = false;
            health.ÑoefficientOfChangeArmor = 1.1f;
        }
        else
        {
            canBeStunned = true;
            health.ÑoefficientOfChangeArmor = 1 / 1.1f;
        }
        inBlock = isEntryBlock;
    }
    public override void EntryStun()
    {
        Debug.Log("IStun");
        animator.SetBool("Stun", true);
        inputController.ChangeState(States.Disable);
    }
    public override void ExitStun()
    {
        inputController.ChangeState(States.Default);
        animator.SetBool("Stun", false);
    }
    public void SubscribeOnEvent()
    {
        inputController.jumpEvent += Jump;
        inputController.jerkEvent += Jerk;
        inputController.blockEvent += BeginBlock;
        inputController.exitBlockEvent += ExitBlock;
        inputController.moveEvent += Move;
        inputController.startStateEvent += StartState;
        inputController.exitStateEvent += ExitState;
    }
    private void StartState(States _state)
    {

    }
    private void ExitState(States _state)
    {
        if (_state == States.Block && inBlock == true)
        {
            Block(false);
        }
    }
}
