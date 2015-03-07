using UnityEngine;
using System.Collections;

public class AttackMeleeHitTrigger : MonoBehaviour {
    [SerializeField]
    private EnemyStateManager manager;

    void OnTriggerStay(Collider col) {
        if (col.name == "Player") {
            manager.startAttackMeleeHit();
        }
    }
}
