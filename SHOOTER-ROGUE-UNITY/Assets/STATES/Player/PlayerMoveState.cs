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
        CheckForShoot(time);

        CheckForJump();
        CheckForAttack();
    }

    public override void OnExit()
    {
    }
}
