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
        float parryMin = stateMachine.attackManager.parryMinTime / 60;
        float parryMax = stateMachine.attackManager.parryMaxTime / 60;
        timerParry += time;
        

        if (timerParry > parryMin && timerParry < parryMax)
        {
            Debug.Log("PARRY !!!");
            if(stateMachine.player.GetComponent<PlayerShieldManager>().isParryOn)
            {
                Debug.Log(timerParry);
                // EFFECT
                stateMachine.NextState(new EnemyHitState(stateMachine));
            }
        }

        timer += time;

        if (timer >= stateMachine.attackManager.attackClip.length)
        {
            Debug.Log(timer);
            stateMachine.NextState(new EnemyMoveState(stateMachine));
        }
    }

    public override void OnExit()
    {
    }
}
