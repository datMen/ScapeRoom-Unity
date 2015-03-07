using UnityEngine;
using System.Collections;
using System.Timers;

public class AttackRangedState : EnemyState {
    private bool shooting = false;

    public AttackRangedState(Context context) {
        this.context = context;
    }

    public override void onEnter() {
        context.agent.SetDestination(context.player.transform.position);
        Debug.Log("Attacking");
    }

    public override void onUpdate() {

        RaycastHit hit;
        Physics.Raycast(context.enemy_tr.position, 
                    (context.player.transform.position - context.enemy_tr.position).normalized, 
                    out hit);
        if (hit.collider.tag != "Player") {
            context.startPatrol();
        }
        else if (!shooting) {
            context.agent.SetDestination(context.player.transform.position);
            shooting = true;
            GameObject ammo = GameObject.Instantiate(context.ammo, context.gun.position, Quaternion.LookRotation(hit.point - context.enemy_tr.position)) as GameObject;
            ammo.GetComponent<Bullet>().startSettings(context.player.transform.position, context.player);

            Timer shootTimer = new Timer(context.fire_rate*100);
            shootTimer.Elapsed += stopShooting;
            shootTimer.AutoReset = false;
            shootTimer.Start();
        }
    }

    public override void onLeave() {}

    public override void startPatrol() {
        context.enemy_target.position = context.player.transform.position;
        context.updateState(EnemyStateId.PatrolState);
    }

    public override void startDetected() {}

    public override void startAttackRanged() {}

    public override void startAttackMelee() {
        context.updateState(EnemyStateId.AttackMeleeState);
    }

    private void stopShooting(System.Object source, ElapsedEventArgs e) {
        shooting = false;
    }

    public override void startAttackMeleeHit() {}
}