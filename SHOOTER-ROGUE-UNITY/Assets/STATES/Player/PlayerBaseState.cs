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


    protected  void CheckForShoot(float time)
    {
        if(stateMachine.inputReader.isShooting)
        {
            if(stateMachine.shootManager.shootTimer >= stateMachine.shootManager.fireRate)
            {
                stateMachine.shootManager.Shoot();
                stateMachine.shootManager.shootTimer = 0;
            }

            if(stateMachine.shootManager.shootTimer != stateMachine.shootManager.fireRate)
            {
                stateMachine.shootManager.shootTimer += time;
            }
        }
    }

    protected void CheckForAttack()
    {
        if (stateMachine.inputReader.inputControls.Player.ATTACK.WasPerformedThisFrame())
        {
            stateMachine.NextState(new PlayerShootState(stateMachine));
        }
    }
    protected void CheckDirection()
    {
            if (stateMachine.inputReader.dirX > 0)
            {
                stateMachine.holder.localRotation = Quaternion.Euler(0, 0, 0);
            }

            if (stateMachine.inputReader.dirX < 0)
            {
                stateMachine.holder.localRotation = Quaternion.Euler(0, 180, 0);
            }
    }



    protected void Move()
    {
        CheckDirection();

        if(stateMachine.inputReader.isMoving)
        {
            stateMachine.animator.Play("Run");
            if (stateMachine.groundDetector.canWalkGround)
            {
                stateMachine.characterController.Move(stateMachine.inputReader.dir * stateMachine.speed * Time.deltaTime);
            }
        }

        else
        {
            stateMachine.animator.Play("Idle");
        }
    }

    protected void CheckForJump()
    {
        if (stateMachine.inputReader.inputControls.Player.JUMP.WasPerformedThisFrame())
        {
            stateMachine.NextState(new PlayerJumpState(stateMachine));
        }
    }

    protected void Jump()
    {
        CheckDirection();
        stateMachine.characterController.Move((stateMachine.transform.up * stateMachine.forceReceiver.jumpForce)  * Time.deltaTime);
        stateMachine.characterController.Move(stateMachine.inputReader.dir * stateMachine.speed  * Time.deltaTime);
    }

    protected void Fall()
    {
        CheckDirection();

        stateMachine.characterController.Move((-stateMachine.transform.up * stateMachine.forceReceiver.gravityMultiplier) * Time.deltaTime);
        stateMachine.characterController.Move(stateMachine.inputReader.dir * stateMachine.speed * Time.deltaTime);
    }
}
