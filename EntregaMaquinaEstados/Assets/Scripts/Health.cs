using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
    private float health;

    void Start () {
        health = 100f;
    }

    public void hurt(float damage) {
        health -= damage;
        Debug.Log(health);
    }
}
