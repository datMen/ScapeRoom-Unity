using UnityEngine;

public interface Context {
    void updateState(EnemyStateId state);
    EnemyStateId getCurStateId();

    Transform enemy_tr { get; }
    Transform enemy_target { get; }
    Transform nav_floor { get; }
    GameObject player { get; }
    GameObject bullet { get; }
    Transform gun { get; }
    NavMeshAgent agent { get; }

    void startPatrol();
    void startDetected();
    void startAttack();
}
