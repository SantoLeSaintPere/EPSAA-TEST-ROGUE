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
    [HideInInspector]
    public Transform player;

    public EnemyType enemyType;
    public SpriteRenderer spriteRenderer;
    [Header("SPEEDS")]
    public float speed = 2.5f;
    public float turnSpeed = 5f;

    [Header("HEALTH")]
    public AnimationClip hurtClip;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        attackManager = GetComponent<EnemyAttackManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        Invoke("Init", 1);
    }

    public void Init()
    {
        NextState(new EnemyMoveState(this));
    }
}
