using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpShootState : PlayerBaseState
{
    float timer;

    public PlayerJumpShootState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void InStart()
    {
        stateMachine.forceReceiver.lastPos = stateMachine.transform.position;
        timer = 0;

        stateMachine.animator.Play("JUMP-SHOOT");

        stateMachine.shootManager.ShowGun();
        stateMachine.shootManager.Shoot();
        stateMachine.shootManager.shootTimer = 0;
    }

    public override void InUpdate(float time)
    {
        ShootBehaviour(time);
        Jump();
        timer += time;
        if (timer >= stateMachine.forceReceiver.jumpTime)
        {
            stateMachine.NextState(new PlayerFallState(stateMachine));
        }
    }

    public override void OnExit()
    {
        stateMachine.shootManager.HideGun();
    }
}
