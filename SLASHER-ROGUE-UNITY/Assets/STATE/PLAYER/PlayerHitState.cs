using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitState : PlayerBaseState
{
    public PlayerHitState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }
    float timer;
    public override void InStart()
    {

        stateMachine.healthManager.hitted = true;
        stateMachine.animator.Play("HIT");
    }

    public override void InUpdate(float time)
    {
        timer += time;
        Move();
        Facing();
        CheckForAttack();
        CheckForShield();

        if(timer >= stateMachine.healthManager.hitClip.length)
        {
            stateMachine.NextState(new PlayerMoveState(stateMachine));
        }
    }

    public override void OnExit()
    {
        stateMachine.healthManager.hitted = false;
    }
}
