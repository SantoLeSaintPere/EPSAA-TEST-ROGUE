using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitState : EnemyBaseState
{
    public EnemyHitState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    float timer;
    public override void InStart()
    {
        stateMachine.animator.Play("HIT");
    }

    public override void InUpdate(float time)
    {
        timer += time;
        StopChasing();

        if(timer >= stateMachine.hurtClip.length)
        {
            stateMachine.NextState(new EnemyMoveState(stateMachine));
        }
    }

    public override void OnExit()
    {
    }
}
