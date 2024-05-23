using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    public PlayerFallState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    float timer, timer2;
    public override void InStart()
    {
        timer = 0;
        timer2 = 0;
    }

    public override void InUpdate(float time)
    {
        timer2 += time; 
            Fall();

        CheckForShoot();

        if (stateMachine.groundDetector.isGrounded)
        {
            timer += time;
            if(stateMachine.inputReader.isShooting)
            {
                stateMachine.animator.Play("Land-Shoot");
            }

            else
            {
                stateMachine.animator.Play("Land");
            }

            Debug.Log("Land");
            if(timer >= stateMachine.forceReceiver.landFrimeRate/60 || stateMachine.inputReader.isMoving)
            {
                stateMachine.NextState(new PlayerMoveState(stateMachine));
            }
        }

        AntiEndlessFallSecurity(timer2);
    }

    public override void OnExit()
    {
    }
}
