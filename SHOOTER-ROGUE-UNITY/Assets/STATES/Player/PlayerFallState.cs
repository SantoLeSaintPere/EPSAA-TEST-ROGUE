using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    public PlayerFallState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    float timer;
    public override void InStart()
    {
        timer = 0;
    }

    public override void InUpdate(float time)
    {

        CheckForShoot(time);
            Fall();

        if(stateMachine.groundDetector.isGrounded)
        {
            timer += time;
            stateMachine.animator.Play("Land");
            Debug.Log("Land");
            if(timer >= stateMachine.forceReceiver.landFrimeRate/60)
            {
                stateMachine.NextState(new PlayerMoveState(stateMachine));
            }
        }
    }

    public override void OnExit()
    {
    }
}
