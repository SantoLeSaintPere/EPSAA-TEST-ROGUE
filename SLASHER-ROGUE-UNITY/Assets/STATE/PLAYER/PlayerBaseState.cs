using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected PlayerStateMachine stateMachine;

    protected PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    protected void Facing()
    {
        if(stateMachine.inputReader.isMoving)
        {
            if(stateMachine.inputReader.direction.x > 0)
            {
                stateMachine.spriteRenderer.flipX = false;
            }

            if (stateMachine.inputReader.direction.x < 0)
            {
                stateMachine.spriteRenderer.flipX = true;
            }
        }
    }

    protected void Move()
    {

        if (stateMachine.inputReader.isMoving)
        {
            if (stateMachine.groundDetector.isGrounded)
            {

                stateMachine.characterController.Move((stateMachine.inputReader.direction) * stateMachine.speed * Time.deltaTime);
            }
            stateMachine.body.rotation = Quaternion.LookRotation(stateMachine.inputReader.direction, Vector3.up);
        }
    }



    protected void ShieldMove()
    {

        if (stateMachine.inputReader.isMoving)
        {
            if (stateMachine.groundDetector.isGrounded)
            {

                stateMachine.characterController.Move((stateMachine.inputReader.direction) * stateMachine.shieldSpeed * Time.deltaTime);
            }
            stateMachine.body.rotation = Quaternion.LookRotation(stateMachine.inputReader.direction, Vector3.up);
        }
    }

    protected void CheckForShield()
    {
        if(stateMachine.shieldManager.canUseShield)
        {
            stateMachine.NextState(new PlayerMoveShieldState(stateMachine));
        }
    }

    protected void CheckForAttack()
    {
        if(stateMachine.inputReader.inputcontrols.Player.ATTACK.WasPerformedThisFrame())
        {
            stateMachine.NextState(new PlayerAttackState(stateMachine));
        }
    }
}
