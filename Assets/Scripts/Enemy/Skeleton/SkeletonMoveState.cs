using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class SkeletonMoveState : SkeletonGroundedState {
    public SkeletonMoveState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Skeleton _enemy) : base(_enemyBase, _stateMachine, _animBoolName, _enemy) {
    }

    public override void Enter() {
        base.Enter();
    }

    public override void Exit() {
        base.Exit();
    }

    public override void Update() {
        base.Update();

        enemy.SetVelocity(enemy.moveSpeed * enemy.facingDir, rb.velocity.y);

        bool wallDetected = enemy.isWallDetected();
        bool groundDetected = enemy.isGroundDetected();

        if (wallDetected || !groundDetected) {
            enemy.Flip();
            stateMachine.ChangeState(enemy.idleState);
        }
    }
}
