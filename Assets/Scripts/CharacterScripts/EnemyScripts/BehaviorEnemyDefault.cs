using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatesEnemy
{
    Idle,
    Agressive,
    Attack,
    Ability,
    Stun
}
public class BehaviorEnemyDefault : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private List<BaseStateEnemy> enemyStates = new List<BaseStateEnemy>();
    [SerializeField] private StatesEnemy currentState = StatesEnemy.Stun;
    public StatesEnemy CurrentState => currentState;
    public GameObject Player => player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Init();
        ChangeState(StatesEnemy.Idle);
    }
    public void Update()
    {
        if ((int)currentState < enemyStates.Count)
        {
            enemyStates[(int)currentState].Update();
        }
    }
    public void ChangeState(StatesEnemy state = StatesEnemy.Idle)
    {
        if ((int)currentState < enemyStates.Count)
        {
            enemyStates[(int)currentState].Exit();
        }
        currentState = state;
        if ((int)currentState < enemyStates.Count)
        {
            enemyStates[(int)currentState].Entry();
        }
    }
    private void Init()
    {
        enemyStates.Add(new IdleStateEnemy());
        enemyStates.Add(new AgressiveStateEnemy());

        foreach (var item in enemyStates)
        {
            item.Init(gameObject);
        }
    }
}
