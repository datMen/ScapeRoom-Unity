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
            context.updateState(EnemyStateId.AttackRangedState);
        }
    }

    public override void startAttackMelee() {
        context.updateState(EnemyStateId.AttackMeleeState);
    }
}