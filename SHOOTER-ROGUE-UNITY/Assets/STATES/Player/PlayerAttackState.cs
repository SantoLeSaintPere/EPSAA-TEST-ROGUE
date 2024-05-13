using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    public PlayerAttackState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }
    float timer;
    public override void InStart()
    {
        stateMachine.animator.Play("Attack");
        timer = 0;
    }

    public override void InUpdate(float time)
    {
        timer += time;

        if (stateMachine.autoRun)
        {
            AutoMove();
        }

        if(timer >= stateMachine.attackManager.attackTime / 60)
        {
            stateMachine.NextState(new PlayerMoveState(stateMachine));
        }

    }

    public override void OnExit()
    {
    }
}
