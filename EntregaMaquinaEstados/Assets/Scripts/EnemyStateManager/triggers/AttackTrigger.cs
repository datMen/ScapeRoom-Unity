using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {
    [SerializeField]
    private EnemyStateManager manager;
    
    void OnTriggerExit(Collider col) {
        if (col.name == "Player") {
            manager.updateState(EnemyStateId.PatrolState);
         }
    }
}
