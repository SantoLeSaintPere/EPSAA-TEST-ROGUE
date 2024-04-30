using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    public PlayerMoveState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void InStart()
    {
    }

    public override void InUpdate(float time)
    {
        Move();
        Facing();
        CheckForAttack();
        CheckForShield();

        if(stateMachine.inputReader.isMoving)
        {
            stateMachine.animator.Play("WALK");
        }

        else
        {
            stateMachine.animator.Play("IDLE");
        }
    }

    public override void OnExit()
    {
    }
}
