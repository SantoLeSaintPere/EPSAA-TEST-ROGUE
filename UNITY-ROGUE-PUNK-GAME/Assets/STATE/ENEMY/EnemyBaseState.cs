using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public abstract class EnemyBaseState : State
{
    protected EnemyStateMachine stateMachine;

    protected EnemyBaseState(EnemyStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    protected void ChasePlayer()
    {
        stateMachine.agent.stoppingDistance = stateMachine.attackManager.stopingDistance;
        stateMachine.agent.isStopped = false;
        stateMachine.agent.speed = stateMachine.speed;
        stateMachine.agent.SetDestination(stateMachine.player.position);
    }


    protected void StopChasing()
    {
        stateMachine.agent.isStopped = true;
    }

    public void FacePlayer()
    {
        Vector3 dir = stateMachine.player.position - stateMachine.transform.position;
        if(dir.x < 0)
        {
            stateMachine.spriteRenderer.flipX = true;
        }

        else
        {
            stateMachine.spriteRenderer.flipX = false;
        }
    }

    public void ShootPoiintFacePlayer()
    {
        Quaternion lookRot = Quaternion.LookRotation(stateMachine.player.position - stateMachine.attackManager.transform.position, Vector3.up);
        stateMachine.attackManager.shooterManager.shootPointHolder.rotation = lookRot;
    }


    public void AimPlayer()
    {
        Quaternion lookRot = Quaternion.LookRotation(stateMachine.player.position - stateMachine.attackManager.transform.position, Vector3.up);
        stateMachine.attackManager.shooterManager.shootPointHolder.rotation = Quaternion.RotateTowards(stateMachine.attackManager.shooterManager.shootPointHolder.rotation, lookRot, (stateMachine.turnSpeed * 100) * Time.deltaTime);
    }

   

    protected void Attack()
    {

    }

    protected void Shoot()
    {

    }

    protected void Explode()
    {

    }
}
