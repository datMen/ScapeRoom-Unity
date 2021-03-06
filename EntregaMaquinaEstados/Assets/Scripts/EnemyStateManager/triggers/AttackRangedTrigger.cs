using UnityEngine;
using System.Collections;

public class AttackRangedTrigger : MonoBehaviour {
    [SerializeField]
    private EnemyStateManager manager;

    void OnTriggerStay(Collider col) {
        if (col.name == "Player") {
            manager.startAttackRanged();
        }
    }
    
    void OnTriggerExit(Collider col) {
        if (col.name == "Player") {
            manager.startPatrol();
        }
    }
}
