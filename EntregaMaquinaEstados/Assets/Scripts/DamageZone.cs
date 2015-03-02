using UnityEngine;
using System.Collections;

public class DamageZone : MonoBehaviour {
    [SerializeField]
    private Health target_health;

    [SerializeField]
    private float damage;

	void OnTriggerStay(Collider col) {
        if (col.name == "Player") {
            target_health.hurt(damage);
        }
    }
}
