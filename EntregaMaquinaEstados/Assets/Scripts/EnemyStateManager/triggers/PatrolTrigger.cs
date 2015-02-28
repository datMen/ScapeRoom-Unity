using UnityEngine;
using System.Collections;

public class PatrolTrigger : MonoBehaviour {
    [SerializeField]
    private EnemyStateManager manager;
    
    void OnTriggerEnter(Collider col) {
        if (col.name == "Player") {
            manager.updateState(EnemyStateId.AttackState);
         }
    }
}
