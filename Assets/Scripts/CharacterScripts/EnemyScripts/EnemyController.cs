using UnityEngine;
using UnityEngine.AI;

public class EnemyController : ControllerBase<Vector3>
{
    private NavMeshAgent navMeshAgent;
    private BehaviorEnemyDefault behaviorEnemy;
    [SerializeField] private Transform originArea;
    [SerializeField] private float rangeArea;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float distanceToPursuit;
    [SerializeField] private float distanceAggression;
    [SerializeField] private float restTime;
    public NavMeshAgent EnemyNavMeshAgent => navMeshAgent;
    public Transform OriginArea => originArea;
    public float RangeArea => rangeArea;
    public Transform PlayerTransform => playerTransform;
    public float DistanceToPursuit => distanceToPursuit;
    public float DistanceAggression => distanceAggression;
    public float RestTime => restTime;
    private void Start()
    {
        behaviorEnemy = GetComponent<BehaviorEnemyDefault>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    public override void Move(Vector3 direction)
    {
        navMeshAgent.destination = direction;
    }
    public override void Rotate(Vector2 direction)
    {

    }
    public override void EntryStun()
    {
        
    }
    public override void ExitStun()
    {

    }

    
}
