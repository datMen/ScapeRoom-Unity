using UnityEngine;

public interface Context {
    void updateState(EnemyStateId state);
    EnemyStateId getCurStateId();

    Transform enemy_tr { get; }
    Transform enemy_target { get; }
    Transform waypoint_tr { get; }
    GameObject player { get; }
    Transform gun { get; }
    GameObject ammo { get; }
    int fire_rate { get; }
    NavMeshAgent agent { get; }
    float initial_stoppingDistance { get; }

    void startPatrol();
    void startDetected();
    void startAttack();
}
