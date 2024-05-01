using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    public PlayerAttackState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    float timer;

    public override void InStart()
    {
        if(stateMachine.attackManager.attackCount == 0)
        {

            stateMachine.animator.Play("ATTACK");
        }


        if (stateMachine.attackManager.attackCount == 1)
        {

            stateMachine.animator.Play("ATTACK-2");
        }



        if (stateMachine.attackManager.attackCount == 2)
        {

            stateMachine.animator.Play("ATTACK-3");
        }
    }

    public override void InUpdate(float time)
    {
        timer += time;

        if (stateMachine.attackManager.attackCount != stateMachine.attackManager.attackClip.Length-1)
        {
            if (timer >= stateMachine.attackManager.timerToRedoAttack[stateMachine.attackManager.attackCount]

                && stateMachine.inputReader.inputcontrols.Player.ATTACK.WasPerformedThisFrame())
            {
                stateMachine.attackManager.attackCount++;
                stateMachine.NextState(new PlayerAttackState(stateMachine));
            }
        }

        if (timer >= stateMachine.attackManager.attackClip[stateMachine.attackManager.attackCount].length)
        {
            stateMachine.attackManager.attackCount = 0;
            stateMachine.NextState(new PlayerMoveState(stateMachine));
        }
    }

    public override void OnExit()
    {
    }
}