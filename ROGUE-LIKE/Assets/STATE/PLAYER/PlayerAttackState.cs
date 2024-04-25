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
        stateMachine.animator.Play("ATTACK");
    }

    public override void InUpdate(float time)
    {
        timer += time;

        if(timer >= stateMachine.attackManager.timerToRedoAttack)
        {
            CheckForAttack();
        }

        if (timer >= stateMachine.attackManager.attackClip.length)
        {
            stateMachine.NextState(new PlayerMoveState(stateMachine));
        }
    }

    public override void OnExit()
    {
    }
}
