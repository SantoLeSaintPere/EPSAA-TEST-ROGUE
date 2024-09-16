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


    protected  void CheckForShoot()
    {
        if(stateMachine.inputReader.inputControls.Player.SHOOT.WasPressedThisFrame())
        {
            stateMachine.shootManager.Shoot();
        }

        if(!stateMachine.inputReader.isShooting)
        {
            stateMachine.shootManager.HideGun();
        }
    }

    protected void CheckDirection()
    {
            if (stateMachine.inputReader.dirX > 0)
            {
                stateMachine.playerBody.localRotation = Quaternion.Euler(0, stateMachine.playerBodyRot, 0);
                stateMachine.holder.localRotation = Quaternion.Euler(0, 0, 0);
            }

            if (stateMachine.inputReader.dirX < 0)
            {
                stateMachine.playerBody.localRotation = Quaternion.Euler(0, -stateMachine.playerBodyRot, 0);
                stateMachine.holder.localRotation = Quaternion.Euler(0,180 , 0);
            }
    }



    protected void Move()
    {
        CheckDirection();

        if(stateMachine.inputReader.isShooting && stateMachine.shootManager.gunOff)
        {
            if (stateMachine.inputReader.isMoving)
            {
                stateMachine.animator.Play("Run-Shoot");
                if (stateMachine.groundDetector.canWalkGround)
                {
                    stateMachine.characterController.Move(stateMachine.inputReader.dir * stateMachine.speed * Time.deltaTime);
                }
            }

            else
            {
                stateMachine.animator.Play("Shoot");
            }
        }

        else
        {
            if (stateMachine.inputReader.isMoving)
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

        if(!stateMachine.groundDetector.isGrounded)
        {
            stateMachine.characterController.Move((-stateMachine.transform.up * stateMachine.forceReceiver.gravityMultiplier) * Time.deltaTime);
        }
    }

    protected void ShootBehaviour()
    {
        if (stateMachine.shootManager.shootTimer >= stateMachine.shootManager.fireRate)
        {
            stateMachine.shootManager.Shoot();
            stateMachine.shootManager.shootTimer = 0;
        }

        if (stateMachine.shootManager.shootTimer != stateMachine.shootManager.fireRate)
        {
            stateMachine.shootManager.shootTimer += Time.deltaTime;
        }
    }


    protected void CheckForJump()
    {
        if (stateMachine.inputReader.inputControls.Player.JUMP.WasPerformedThisFrame())
        {
            stateMachine.NextState(new PlayerJumpState(stateMachine));
        }
    }

    protected void CheckForCrunch()
    {
        if(stateMachine.inputReader.inputControls.Player.CRUNCH.WasPerformedThisFrame() 
            && stateMachine.plateformDetector.isOnPlateform)
        {
            stateMachine.NextState(new PlayerFallState(stateMachine));
        }
    }

    protected void Jump()
    {
        if (stateMachine.inputReader.isShooting)
        {
            stateMachine.animator.Play("Jump-Shoot");
        }

        else
        {
            stateMachine.animator.Play("Jump");
        }

        CheckDirection();
        stateMachine.characterController.Move((stateMachine.transform.up * stateMachine.forceReceiver.jumpForce)  * Time.deltaTime);
        stateMachine.characterController.Move(stateMachine.inputReader.dir * (stateMachine.speed *2)  * Time.deltaTime);
    }

    protected void Fall()
    {
        CheckDirection();

        stateMachine.characterController.Move((-stateMachine.transform.up * stateMachine.forceReceiver.gravityMultiplier) * Time.deltaTime);
        stateMachine.characterController.Move(stateMachine.inputReader.dir * stateMachine.speed * Time.deltaTime);
    }

    protected void AntiEndlessFallSecurity(float timer)
    {
        if (!stateMachine.groundDetector.isGrounded && timer >= stateMachine.forceReceiver.fallMaxTime)
        {
            stateMachine.transform.position = stateMachine.forceReceiver.lastPos;
            stateMachine.NextState(new PlayerMoveState(stateMachine));
        }
    }
}
