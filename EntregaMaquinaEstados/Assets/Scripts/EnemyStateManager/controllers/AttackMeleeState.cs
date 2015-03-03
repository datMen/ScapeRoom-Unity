using UnityEngine;
using System.Collections;
using System.Timers;

public class AttackMeleeState : EnemyState {
    private Quaternion initial_rotation;
    private bool goDetected = false;

    public AttackMeleeState(Context context) {
        this.context = context;
    }

    public override void onEnter() {
        initial_rotation = context.enemy_body_tr.rotation;
        context.agent.stoppingDistance = 0;
    }

    public override void onUpdate() {
        context.agent.SetDestination(context.player.transform.position);
        context.enemy_body_tr.Rotate(Vector3.up, Time.deltaTime * 1000F);
    }

    public override void onLeave() {
        context.agent.stoppingDistance = context.initial_stoppingDistance;
        context.enemy_body_tr.localEulerAngles = new Vector3(0, 0, 0);
    }

    public override void startPatrol() {}

    public override void startDetected() {
        context.updateState(EnemyStateId.DetectedState);
    }

    public override void startAttackRanged() {}
    
    public override void startAttackMelee() {}
}