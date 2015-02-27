using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour {
    [SerializeField]
    private GameObject Enemy;

    // Use this for initialization
    void Start () {

    }

    void OnTriggerStay(Collider col) {
        RaycastHit hit;
        Physics.Raycast(Enemy.transform.position, (col.transform.position - Enemy.transform.position), out hit);

        if (hit.collider.tag == "Player") {
            // Debug.DrawLine(Enemy.transform.position, hit.point, Color.red);
        }
    }

    void OnTriggerExit(Collider col) {
        RaycastHit hit;
        Physics.Raycast(Enemy.transform.position, (col.transform.position - Enemy.transform.position), out hit);

        if (hit.collider.tag == "Player") {
            // Debug.DrawLine(Enemy.transform.position, hit.point, Color.red);
        }
    }
}
