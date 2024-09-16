using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveShieldState : PlayerBaseState
{
    public PlayerMoveShieldState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    float timer;

    public override void InStart()
    {
        timer = 0;
        stateMachine.shieldManager.isParryOn = true;
    }

    public override void InUpdate(float time)
    {
        timer += time;
        if(timer >= stateMachine.shieldManager.parryWindow)
        {
            stateMachine.shieldManager.isParryOn = false;
            timer = stateMachine.shieldManager.parryWindow;
        }

        CheckForAttack();
        ShieldMove();
        Facing();



        if (stateMachine.inputReader.isMoving)
        {
            stateMachine.animator.Play("SHIELD-WALK");
        }

        else
        {
            stateMachine.animator.Play("SHIELD-IDLE");
        }

        if (!stateMachine.shieldManager.canUseShield)
        {
            stateMachine.NextState(new PlayerMoveState(stateMachine));
        }
    }

    public override void OnExit()
    {
        stateMachine.shieldManager.isParryOn = false;
    }
}
