using UnityEngine;

public interface Context {
    void updateState(EnemyStateId state);
    EnemyStateId getCurStateId();

    Transform enemy_tr { get; }
    Transform enemy_target { get; }
    Transform waypoint_range { get; }
    GameObject player { get; }
    Transform gun { get; }
    GameObject ammo { get; }
    int fire_rate { get; }
    NavMeshAgent agent { get; }
    float initial_stoppingDistance { get; }
    Vector3 waypoint_start_pos { get; }

    void startPatrol();
    void startDetected();
    void startAttack();
}
