using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public PlayerJumpState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }
    float timer;
    public override void InStart()
    {
        stateMachine.forceReceiver.lastPos = stateMachine.transform.position;
        stateMachine.animator.Play("Jump");
        timer = 0;
    }

    public override void InUpdate(float time)
    {
            Jump();

        timer += time;
        if(timer >= stateMachine.forceReceiver.jumpTime)
        {
            stateMachine.NextState(new PlayerFallState(stateMachine));
        }
    }

    public override void OnExit()
    {
    }
}
