using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootState : EnemyBaseState
{
    public EnemyShootState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }
    float timer;
    public override void InStart()
    {
        StopChasing();
    }

    public override void InUpdate(float time)
    {
        timer += Time.deltaTime;

        if(timer < stateMachine.attackManager.shooterManager.coolDown)
        {
            stateMachine.animator.Play("AIM");
            //AimPlayer();
            FacePlayer();
        }

        if (timer >= stateMachine.attackManager.shooterManager.fireRate)
        {
            stateMachine.animator.Play("ATTACK");
            stateMachine.attackManager.Shoot();
            stateMachine.NextState(new EnemyMoveState(stateMachine));
        }
    }

    public override void OnExit()
    {
    }
}
