using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyBaseState
{
    public EnemyMoveState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void InStart()
    {
        stateMachine.animator.Play("IDLE");
    }

    public override void InUpdate(float time)
    {
        ChasePlayer();

        if(stateMachine.enemyType == EnemyType.shooter)
        {
            AimPlayer();
        }

        if(stateMachine.attackManager.isInAttackZone)
        {
            if(stateMachine.enemyType == EnemyType.shooter)
            {
                stateMachine.NextState(new EnemyShootState(stateMachine));
            }

            else
            {
                stateMachine.NextState(new EnemyAttackState(stateMachine));
            }
        }
    }

    public override void OnExit()
    {

    }
}
