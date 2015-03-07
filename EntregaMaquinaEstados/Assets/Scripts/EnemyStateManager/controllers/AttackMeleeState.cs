using UnityEngine;
using System.Collections;
using System.Timers;

public class AttackMeleeState : EnemyState {
    private bool inRecoil = false;

    public AttackMeleeState(Context context) {
        this.context = context;
    }

    public override void onEnter() {
        context.agent.speed *= 2;
        context.agent.acceleration *= 3;
        inRecoil = false;
    }

    public override void onUpdate() {
        if (Vector3.Distance(context.enemy_tr.position, context.player.transform.position) <= 1f) {
            if (!inRecoil) {
                context.player.GetComponent<Health>().hurt(context.melee_damage);
                context.agent.velocity *= -1;
                setRandomWayPoint();
            }
            inRecoil = true;
        }

        if (inRecoil) {
            if (context.agent.remainingDistance <= 0.1f) {
                inRecoil = false;
            }
            context.agent.SetDestination(context.enemy_target.position);
        }
        else {
            context.agent.SetDestination(context.player.transform.position);
        }
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

    private void setRandomWayPoint() {
        float waypoint_range = context.melee_range_col.bounds.size.z/2;
        context.enemy_target.position = new Vector3(
            Random.Range(-waypoint_range, waypoint_range) + context.player.transform.position.x, 
            context.enemy_target.position.y, 
            Random.Range(-waypoint_range, waypoint_range) + context.player.transform.position.z
        );
    }
}