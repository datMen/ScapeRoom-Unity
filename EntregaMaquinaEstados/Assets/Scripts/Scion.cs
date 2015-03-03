using UnityEngine;
using System.Collections;

public class Scion : MonoBehaviour {
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float damage;

    [SerializeField]
    private Transform enemy_tr;

    void OnTriggerEnter(Collider col) {
        if (col.name == "Player") {
            player.GetComponent<Health>().hurt(damage);
        }
    }
}
