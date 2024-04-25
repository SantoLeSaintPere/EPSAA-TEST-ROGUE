using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyType
{
    melee, shooter, bomb
}
public class EnemyStateMachine : StateMachine
{
    [HideInInspector]
    public NavMeshAgent agent;
    [HideInInspector]
    public Animator animator;
    [HideInInspector]
    public EnemyAttackManager attackManager;


    public EnemyType enemyType;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        attackManager = GetComponent<EnemyAttackManager>();
    }
}
