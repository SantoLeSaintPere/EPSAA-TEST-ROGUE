using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [HideInInspector]
    public PlayerInputReader inputReader;
    [HideInInspector]
    public CharacterController characterController;
    [HideInInspector]
    public PlayerGroundDetector groundDetector;
    [HideInInspector]
    public Animator animator;
    [HideInInspector]
    public SpriteRenderer spriteRenderer;
    [HideInInspector]
    public PlayerAttackManager attackManager;
    [HideInInspector]
    public PlayerHealthManager healthManager;
    [HideInInspector]
    public PlayerShieldManager shieldManager;

    public float speed;
    public float shieldSpeed;
    [HideInInspector]
    public Transform body;
    // Start is called before the first frame update
    void Start()
    {
        inputReader = GetComponent<PlayerInputReader>();
        characterController = GetComponent<CharacterController>();
        groundDetector = GetComponent<PlayerGroundDetector>();

        attackManager = GetComponent<PlayerAttackManager>();
        healthManager = GetComponent<PlayerHealthManager>();
        shieldManager = GetComponent<PlayerShieldManager>();
        body = transform.GetChild(0);


        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        NextState(new PlayerMoveState(this));
    }


}
