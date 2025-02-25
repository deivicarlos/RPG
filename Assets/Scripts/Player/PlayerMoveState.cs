using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundState {
    public PlayerMoveState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName) {
    }

    public override void Enter() {
        base.Enter();
    }

    public override void Exit() {
        base.Exit();
    }

    public override void Update() {
        player.SetVelocity(xInput * player.moveSpeed, rb.velocity.y);

        base.Update();

        if (xInput == 0 || player.isWallDetected()) {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
