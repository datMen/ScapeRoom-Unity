using UnityEngine;
using System.Collections;

public class DetectTrigger : MonoBehaviour {
    [SerializeField]
    private EnemyStateManager manager;

    void OnTriggerStay(Collider col) {
        if (col.name == "Player") {
            manager.startDetected();
        }
    }
    
    void OnTriggerExit(Collider col) {
        if (col.name == "Player") {
            manager.startPatrol();
         }
    }
}
