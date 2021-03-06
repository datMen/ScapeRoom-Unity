using UnityEngine;
using System.Collections;

public class PatrolState : EnemyState {
    private Vector3 waypoint_range;

    public PatrolState(Context context) {
        this.context = context;
        this.waypoint_range = context.waypoint_tr.transform.localScale*5;
    }

    private void setRandomWayPoint() {
        context.enemy_target.position = new Vector3(
            Random.Range(-waypoint_range.x, waypoint_range.x)+context.waypoint_tr.position.x, 
            context.enemy_target.position.y, 
            Random.Range(-waypoint_range.z, waypoint_range.z)+context.waypoint_tr.position.z
        );
        context.agent.SetDestination(context.enemy_target.position);
    }

    public override void onEnter() {
        Debug.Log("Patrolling");
        context.agent.SetDestination(context.enemy_target.position);
    }

    public override void onUpdate() {
        if (context.agent.remainingDistance <= 0.1f) { // Agent is too close to the waypoint
           setRandomWayPoint();
        }
    }

    public override void onLeave() {}

    public override void startPatrol() {}

    public override void startDetected() {
        context.updateState(EnemyStateId.DetectedState);
    }

    public override void startAttackRanged() {
        NavMeshHit hit;
        if (!context.agent.Raycast(context.player.transform.position, out hit)) {
            context.updateState(EnemyStateId.AttackRangedState);
        }
    }

    public override void startAttackMelee() {}
}