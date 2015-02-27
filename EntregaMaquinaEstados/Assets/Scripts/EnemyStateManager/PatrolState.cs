using UnityEngine;
using System.Collections;

public class PatrolState : EnemyState {
    private EnemyStateManager manager;

    private Vector3 nav_floor_size;
    float taget_max_distance = 2.5F;

    public PatrolState(EnemyStateManager manager) {
        this.manager = manager;
        nav_floor_size = manager.nav_floor.transform.localScale*5;
    }

    private void setRandomWayPoint() {
        manager.enemy_target.position = new Vector3(Random.Range(-nav_floor_size.x, nav_floor_size.x), manager.enemy_target.position.y, Random.Range(-nav_floor_size.z, nav_floor_size.z));
        manager.agent.SetDestination(manager.enemy_target.position);
    }

    private float getWayPointDistance() {
        return Vector3.Distance(manager.transform.position, manager.enemy_target.position);
    }

    public override void onEnter() {
        Debug.Log("Patrullando");
        manager.agent.SetDestination(manager.enemy_target.position);
    }

    public override void onUpdate() {
        if (getWayPointDistance() < taget_max_distance) { // Agent is too close to the waypoint
           setRandomWayPoint();
        }
    }
    
    public override void Patrol() {}
    public override void Attack() {}

    public override void onLeave() {}
}