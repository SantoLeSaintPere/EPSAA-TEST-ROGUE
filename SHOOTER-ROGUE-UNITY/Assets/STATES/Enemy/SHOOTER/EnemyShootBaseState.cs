using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyShootBaseState : State
{
    protected EnemyShootStateMachine stateMachine;

    protected EnemyShootBaseState(EnemyShootStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    protected void CheckInAttackRangePlayer()
    {
        if(stateMachine.rangesManager.isInAttackRange)
        {
            stateMachine.NextState(new EnemyShootShootState(stateMachine));
        }
    }

    protected void Move()
    {
        if(stateMachine.rangesManager.isInDetectionRange && stateMachine.groundDetector.isGrounded)
        {
            stateMachine.animator.Play("RUN");
            Vector3 direction = stateMachine.player.position - stateMachine.transform.position;
            stateMachine.transform.Translate(new Vector3(direction.x,0,0) * stateMachine.speed * Time.deltaTime);
        }

        else
        {
            stateMachine.animator.Play("IDLE");
        }
    }

    protected void FacePlayer()
    {

        if(stateMachine.rangesManager.isInDetectionRange)
        {
            Vector3 direction = stateMachine.player.position - stateMachine.transform.position;
            if (direction.x > 0)
            {
                Debug.Log("LEFT");
                stateMachine.holder.localRotation = Quaternion.Euler(0, 180, 0);
                stateMachine.body.localRotation = Quaternion.Euler(0, stateMachine.bodyRot, 0);
            }


            if (direction.x < 0)
            {
                Debug.Log("RIGHT");
                stateMachine.holder.localRotation = Quaternion.Euler(0, 0, 0);
                stateMachine.body.localRotation = Quaternion.Euler(0, -stateMachine.bodyRot, 0);
            }
        }
    }

    protected void Shoot()
    {

    }
}
