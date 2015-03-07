using UnityEngine;
using System.Collections;

public class AttackMeleeTrigger : MonoBehaviour {
    [SerializeField]
    private EnemyStateManager manager;

    void OnTriggerStay(Collider col) {
        if (col.name == "Player") {
            manager.startAttackMelee();
        }
    }

    void OnTriggerExit(Collider col) {
        if (col.name == "Player") {
            manager.startDetected();
        }
    }
}
