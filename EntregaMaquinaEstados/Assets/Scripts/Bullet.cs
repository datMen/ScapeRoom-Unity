using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    private Health target_health;

    private RaycastHit destiny_hit;
    private bool start = false;
    private float damage = 1f;

    void Update() {
        if (start) {
            if (Vector3.Distance(transform.position, destiny_hit.point) < 0.1F) {
                Destroy(this.gameObject);
            }
            Debug.DrawLine(transform.position, destiny_hit.point, Color.red);
            transform.position = Vector3.MoveTowards(transform.position, destiny_hit.point, Time.deltaTime * 25.0f);
        }
    }

    public void startSettings(Vector3 destiny_point, GameObject target) {
        this.target_health = target.GetComponent<Health>();
        Physics.Raycast(destiny_point, 
                        (destiny_point - transform.position), 
                        out destiny_hit);
        start = true;
    }

    void OnTriggerEnter(Collider col) {
        if (col.name == "Player") {
            target_health.hurt(damage);
            Destroy(this.gameObject);
        }
    }
}

