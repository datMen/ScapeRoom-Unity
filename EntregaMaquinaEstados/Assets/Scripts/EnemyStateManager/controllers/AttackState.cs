using UnityEngine;
using System.Collections;
using System.Timers;

public class AttackState : EnemyState {
    private bool shooting = false;
    private int fire_rate = 500;

    public AttackState(Context context) {
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
            GameObject bullet = GameObject.Instantiate(context.bullet, context.gun.position, context.enemy_tr.rotation) as GameObject;
            bullet.GetComponent<Bullet>().startSettings(context.player.transform.position, context.player);

            Timer shootTimer = new Timer(fire_rate);
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

    public override void startAttack() {}

    private float getEnemyPlayerDistance() {
        return Vector3.Distance(context.player.transform.position, context.enemy_tr.position);
    }

    private bool isInDamageRange() {
        return (context.agent.stoppingDistance*5)/3 > getEnemyPlayerDistance();
    }

    private void stopShooting(System.Object source, ElapsedEventArgs e) {
        shooting = false;
    }
}