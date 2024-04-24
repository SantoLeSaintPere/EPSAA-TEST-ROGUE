using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveShieldState : PlayerBaseState
{
    public PlayerMoveShieldState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void InStart()
    {
        stateMachine.animator.Play("SHIELD-MOVE");
    }

    public override void InUpdate(float time)
    {
        CheckForAttack();
        ShieldMove();
        Facing();



        if (stateMachine.inputReader.isMoving)
        {
            stateMachine.animator.Play("SHIELD-WALK");
        }

        else
        {
            stateMachine.animator.Play("SHIELD-IDLE");
        }

        if (!stateMachine.inputReader.isHoldingShield)
        {
            stateMachine.NextState(new PlayerMoveState(stateMachine));
        }
    }

    public override void OnExit()
    {
    }
}
