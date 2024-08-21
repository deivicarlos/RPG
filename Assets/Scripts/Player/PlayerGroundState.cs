using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerGroundState : PlayerState {
    public PlayerGroundState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName) {
    }

    public override void Enter() {
        base.Enter();
    }

    public override void Exit() {
        base.Exit();
    }

    public override void Update() {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Mouse1) && HasNoSword()) {
            stateMachine.ChangeState(player.aimSwordState);
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            stateMachine.ChangeState(player.counterAttackState);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0)
        ) {
            stateMachine.ChangeState(player.attackState);
        }

        if (!player.isGroundDetected()) {
            stateMachine.ChangeState(player.airState);
        }

        if (Input.GetKeyDown(KeyCode.Space) && player.isGroundDetected()) {
            stateMachine.ChangeState(player.jumpState);
        }

    }

    private bool HasNoSword() {
        if (!player.sword) {
            return true;
        }

        player.sword.GetComponent<SwordSkillController>().ReturnSword();
        return false;
    }
}
