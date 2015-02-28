using UnityEngine;
using System.Collections;

public class AttackState : EnemyState {

    public AttackState(Context context) {
        this.context = context;
    }

    public override void onEnter() {
        Debug.Log("Attacking");
    }

    public override void onUpdate() {
        context.agent.SetDestination(context.player.transform.position);
    }

    public override void onLeave() {}
}