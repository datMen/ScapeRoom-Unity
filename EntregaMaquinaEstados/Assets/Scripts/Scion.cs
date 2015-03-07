using UnityEngine;
using System.Collections;

public class Scion : MonoBehaviour {
    [SerializeField]
    private EnemyStateManager manager;

    [SerializeField]
    private float damage;

    void OnTriggerEnter(Collider col) {
        if (col.name == "Player") {
            manager.startAttackMeleeHit();
        }
    }
}
