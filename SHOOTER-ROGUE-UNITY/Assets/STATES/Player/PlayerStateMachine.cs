using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [HideInInspector]
    public CharacterController characterController;
    [HideInInspector]
    public PlayerInputReader inputReader;
    [HideInInspector]
    public PlayerForceReceiver forceReceiver;
    [HideInInspector]
    public PlayerGroundDetector groundDetector;
    [HideInInspector]
    public PlayerAttackManager attackManager;
    [HideInInspector]
    public PlayerShootManager shootManager;


    [HideInInspector]
    public Animator animator;

    public float playerBodyRot = 60f;
    public Transform playerBody;

    public Transform holder;

    [Header("MOTION")]
    public float speed = 5f;



    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        inputReader = GetComponent<PlayerInputReader>();
        forceReceiver = GetComponent<PlayerForceReceiver>();
        groundDetector = GetComponent<PlayerGroundDetector>();
        attackManager = GetComponent<PlayerAttackManager>();
        shootManager = GetComponent<PlayerShootManager>();

        animator = GetComponentInChildren<Animator>();



        NextState(new PlayerMoveState(this));
    }
}
