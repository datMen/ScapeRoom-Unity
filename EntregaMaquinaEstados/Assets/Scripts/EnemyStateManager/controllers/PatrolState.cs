using UnityEngine;
using System.Collections;

public class PatrolState : EnemyState {
    private Vector3 waypoint_range;
    float taget_max_distance;

    public PatrolState(Context context) {
        this.context = context;
        this.waypoint_range = context.waypoint_tr.transform.localScale*5;
        taget_max_distance = context.agent.stoppingDistance;
    }

    private void setRandomWayPoint() {
        context.enemy_target.position = new Vector3(Random.Range(-waypoint_range.x, waypoint_range.x)+context.waypoint_tr.position.x, context.enemy_target.position.y, Random.Range(-waypoint_range.z, waypoint_range.z)+context.waypoint_tr.position.z);
        context.agent.SetDestination(context.enemy_target.position);
    }

    public override void onEnter() {
        Debug.Log("Patrolling");
        context.agent.SetDestination(context.enemy_target.position);
    }

    public override void onUpdate() {
        if (context.agent.remainingDistance <= taget_max_distance) { // Agent is too close to the waypoint
           setRandomWayPoint();
        }
    }

    public override void onLeave() {}

    public override void startPatrol() {}

    public override void startDetected() {
        context.updateState(EnemyStateId.DetectedState);
    }

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

    public override void startAttackMelee() {}
}