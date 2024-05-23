using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootShootState : EnemyShootBaseState
{
    public EnemyShootShootState(EnemyShootStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void InStart()
    {
        stateMachine.animator.Play("SHOOT");
    }

    public override void InUpdate(float time)
    {
        if(!stateMachine.rangesManager.isInAttackRange)
        {
            stateMachine.NextState(new EnemyShootMoveState(stateMachine));
        }
    }

    public override void OnExit()
    {

    }
}
