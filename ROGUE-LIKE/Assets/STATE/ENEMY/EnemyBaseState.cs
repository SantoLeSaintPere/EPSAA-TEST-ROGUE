using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState : State
{
    protected EnemyStateMachine stateMachine;

    protected EnemyBaseState(EnemyStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    protected void Move()
    {

    }

    protected void CheckForAttack()
    {

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
