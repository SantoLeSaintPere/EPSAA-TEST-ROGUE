using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootStateMachine : StateMachine
{
    [HideInInspector]
    public EnemyGroundDetector groundDetector;
    [HideInInspector]
    public EnemyShootManager shootManager;
    [HideInInspector]
    public EnemyRangesManager rangesManager;

    [HideInInspector]
    public Transform player;

    [HideInInspector]
    public Animator animator;

    public float speed = 2.5f;
    [Header("BODY + HOLDER")]
    public float bodyRot = 90f;
    public Transform body, holder;
    // Start is called before the first frame update
    void Start()
    {
        groundDetector = GetComponent<EnemyGroundDetector>();
        shootManager = GetComponent<EnemyShootManager>();
        rangesManager = GetComponent<EnemyRangesManager>();

        player = GameObject.FindWithTag("Player").transform;


        animator = GetComponentInChildren<Animator>();

        NextState(new EnemyShootMoveState(this));
    }
}
