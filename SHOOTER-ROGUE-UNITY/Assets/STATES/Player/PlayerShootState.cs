using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootState : PlayerBaseState
{
    public PlayerShootState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }
    public override void InStart()
    {
        stateMachine.shootManager.ShowGun();
    }

    public override void InUpdate(float time)
    {
        ShootBehaviour(time);

        MoveShoot();

        if (!stateMachine.inputReader.isShooting)
        {
            stateMachine.NextState(new PlayerMoveState(stateMachine));
        }

    }

    public override void OnExit()
    {
        stateMachine.shootManager.HideGun();
    }
}
