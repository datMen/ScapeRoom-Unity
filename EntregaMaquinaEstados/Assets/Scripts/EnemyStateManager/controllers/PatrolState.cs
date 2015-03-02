using UnityEngine;
using System.Collections;

public class PatrolState : EnemyState {
    private Vector3 nav_floor_size;
    float taget_max_distance;

    public PatrolState(Context context) {
        this.context = context;
        nav_floor_size = context.nav_floor.transform.localScale*5;
        taget_max_distance = context.agent.stoppingDistance;
    }

    private void setRandomWayPoint() {
        context.enemy_target.position = new Vector3(Random.Range(-nav_floor_size.x, nav_floor_size.x), context.enemy_target.position.y, Random.Range(-nav_floor_size.z, nav_floor_size.z));
        context.agent.SetDestination(context.enemy_target.position);
    }

    public override void onEnter() {
        Debug.Log("Patrolling");
        context.agent.SetDestination(context.enemy_target.position);
    }

    public override void onUpdate() {
        if (context.agent.remainingDistance < taget_max_distance) { // Agent is too close to the waypoint
           setRandomWayPoint();
        }
    }

    public override void onLeave() {}

    public override void startPatrol() {}

    public override void startDetected() {
        context.updateState(EnemyStateId.DetectedState);
    }

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