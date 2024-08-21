using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonGroundedState : EnemyState {
    protected Enemy_Skeleton enemy;
    protected Transform player;
    public SkeletonGroundedState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Skeleton _enemy) : base(_enemyBase, _stateMachine, _animBoolName) {
        this.enemy = _enemy;
    }

    // Start is called before the first frame update
    public override void Enter() {
        base.Enter();
        player = PlayerManager.instance.transform;
    }

    // Update is called once per frame
    public override void Update() {
        base.Update();

        if (enemy.IsPlayerDetected() || Vector2.Distance(player.transform.position, enemy.transform.position) < 2) {
            stateMachine.ChangeState(enemy.battleState);
        }
    }

    public override void Exit() {
        base.Exit();
    }
}
