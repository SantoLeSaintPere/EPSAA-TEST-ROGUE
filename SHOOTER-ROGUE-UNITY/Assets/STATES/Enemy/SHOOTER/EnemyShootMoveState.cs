using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootMoveState : EnemyShootBaseState
{
    public EnemyShootMoveState(EnemyShootStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void InStart()
    {
    }

    public override void InUpdate(float time)
    {
        Move();
        FacePlayer();

        CheckInAttackRangePlayer();
    }

    public override void OnExit()
    {
    }
}
