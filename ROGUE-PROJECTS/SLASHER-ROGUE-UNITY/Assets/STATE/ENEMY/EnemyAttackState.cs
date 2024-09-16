using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    public EnemyAttackState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    float timer;
    float timerParry;

    public override void InStart()
    {


        timer = 0;
        timerParry = 0;
        FacePlayer();
        StopChasing();
        stateMachine.animator.Play("ATTACK");
    }

    public override void InUpdate(float time)
    {
        float parryMin = stateMachine.attackManager.parryMinFrame / 60;
        float parryMax = stateMachine.attackManager.parryMaxFrame / 60;
        timerParry += time;
        

        if (timerParry > parryMin && timerParry < parryMax)
        {
            if(stateMachine.player.GetComponent<PlayerShieldManager>().isParryOn)
            {
                // EFFECT
                stateMachine.NextState(new EnemyHitState(stateMachine));
            }
        }

        timer += time;

        if (timer >= stateMachine.attackManager.attackClip.length)
        {
            stateMachine.NextState(new EnemyMoveState(stateMachine));
        }
    }

    public override void OnExit()
    {
    }
}
