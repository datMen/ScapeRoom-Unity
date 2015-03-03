using UnityEngine;
using System.Collections;

public class DetectTrigger : MonoBehaviour {
    [SerializeField]
    private EnemyStateManager manager;

    void OnTriggerStay(Collider col) {
        if (col.name == "Player") {
            if (Vector3.Distance(manager.enemy_tr.position, manager.player.transform.position) <= manager.initial_stoppingDistance) {
                manager.startAttackMelee();
            }
            else {
                manager.startDetected();
            }
        }
    }
    
    void OnTriggerExit(Collider col) {
        if (col.name == "Player") {
            manager.startPatrol();
         }
    }
}
