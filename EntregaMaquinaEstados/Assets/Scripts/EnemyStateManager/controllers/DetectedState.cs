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
        if (Vector3.Distance(context.enemy_tr.position, context.player.transform.position) <= context.agent.stoppingDistance) {
            Vector3 targetPoint = new Vector3(context.player.transform.position.x, context.enemy_tr.position.y, context.player.transform.position.z);
            context.enemy_tr.rotation = Quaternion.Slerp(context.enemy_tr.rotation, Quaternion.LookRotation(targetPoint - context.enemy_tr.position), Time.deltaTime * 2F);
        }
        context.agent.SetDestination(context.player.transform.position);
    }

    public override void onLeave() {}

    public override void startPatrol() {
        context.enemy_target.position = context.player.transform.position;
        context.updateState(EnemyStateId.PatrolState);
    }

    public override void startDetected() {}

    public override void startAttack() {
        RaycastHit hit;
        Physics.Raycast(context.enemy_tr.position, 
                    (context.player.transform.position - context.enemy_tr.position).normalized, 
                    out hit);
        Debug.DrawLine(context.enemy_tr.position, hit.point, Color.white);
        if (hit.collider.tag == "Player") {
            context.updateState(EnemyStateId.AttackState);
        }
    }
}