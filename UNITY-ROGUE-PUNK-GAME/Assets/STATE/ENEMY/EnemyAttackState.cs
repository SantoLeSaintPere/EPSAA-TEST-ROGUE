using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    public EnemyAttackState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    float timer;

    public override void InStart()
    {
        StopChasing();
        stateMachine.animator.Play("ATTACK");
    }

    public override void InUpdate(float time)
    {
        timer += Time.deltaTime;

        if (timer >= stateMachine.attackManager.attackClip.length)
        {
            stateMachine.NextState(new EnemyMoveState(stateMachine));
        }
    }

    public override void OnExit()
    {
    }
}
