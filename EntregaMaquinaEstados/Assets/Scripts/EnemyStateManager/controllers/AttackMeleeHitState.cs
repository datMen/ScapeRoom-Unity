using UnityEngine;
using System.Collections;
using System.Timers;

public class AttackMeleeHitState : EnemyState {

    public AttackMeleeHitState(Context context) {
        this.context = context;
    }

    public override void onEnter() {
        context.agent.speed *= 2;
        context.agent.acceleration *= 3;
        context.agent.velocity *= -1;
        context.player.GetComponent<Health>().hurt(context.melee_damage);
        setRandomWayPoint();
    }

    public override void onUpdate() {
        if (Vector3.Distance(context.enemy_tr.position, context.player.transform.position) <= 2f) {
            context.agent.velocity *= -1;
        }
        if (context.agent.remainingDistance <= 0.1f) {
            context.updateState(EnemyStateId.AttackMeleeState);
        }
        context.agent.SetDestination(context.enemy_target.position);
        context.enemy_body_tr.Rotate(Vector3.up, Time.deltaTime * 2000F);
    }

    public override void onLeave() {
        context.enemy_body_tr.localEulerAngles = new Vector3(0, 0, 0);
        context.agent.speed /= 2;
        context.agent.acceleration /= 3;
    }

    public override void startPatrol() {}

    public override void startDetected() {
        context.updateState(EnemyStateId.DetectedState);
    }

    public override void startAttackRanged() {}
    
    public override void startAttackMelee() {}

    public override void startAttackMeleeHit() {}

    private void setRandomWayPoint() {
        float waypoint_range = context.melee_range_col.bounds.size.z/2;
        context.enemy_target.position = new Vector3(
            Random.Range(-waypoint_range, waypoint_range) + context.player.transform.position.x, 
            context.enemy_target.position.y, 
            Random.Range(-waypoint_range, waypoint_range) + context.player.transform.position.z
        );
    }
}