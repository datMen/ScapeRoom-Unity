using UnityEngine;
using System.Collections;

public class DetectedState : EnemyState {

    public DetectedState(Context context) {
        this.context = context;
    }

    public override void onEnter() {
        Debug.Log("Player detected");
    }

    public override void onUpdate() {
        if (Vector3.Distance(context.enemy_tr.position, context.player.transform.position) <= context.initial_stoppingDistance) {
            context.updateState(EnemyStateId.AttackMeleeState);
        }
        context.agent.SetDestination(context.player.transform.position);
    }

    public override void onLeave() {}

    public override void startPatrol() {
        context.enemy_target.position = context.player.transform.position;
        context.updateState(EnemyStateId.PatrolState);
    }

    public override void startDetected() {}

    public override void startAttackRanged() {
        RaycastHit hit;
        Physics.Raycast(context.enemy_tr.position, 
                    (context.player.transform.position - context.enemy_tr.position).normalized, 
                    out hit);
        Debug.DrawLine(context.enemy_tr.position, hit.point, Color.white);
        if (hit.collider.tag == "Player") {
            context.agent.stoppingDistance = context.initial_stoppingDistance;
            context.updateState(EnemyStateId.AttackRangedState);
        }
        else {
            context.agent.stoppingDistance = context.initial_stoppingDistance/3;
        }
    }

    public override void startAttackMelee() {}
}