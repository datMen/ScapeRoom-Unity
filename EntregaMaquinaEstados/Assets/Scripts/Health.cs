using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
    [SerializeField]
    private GameObject health_bar;

    [SerializeField]
    private GameObject health_label;

    [SerializeField]
    private GameObject gameover_label;

    private float health_bar_width;
    private float health;

    void Start () {
        health_bar_width = health_bar.transform.localScale.y;
        health = health_bar_width;

    }

    public void hurt(float damage) {
        float damage_percent = (damage/10)/health_bar_width;
        if (health <= 0.01f) {
            Destroy(health_bar);
            Destroy(health_label);
            gameover_label.transform.position = new Vector3(-0.1f, gameover_label.transform.position.y, gameover_label.transform.position.z);
            Destroy(this.gameObject, 0.5f);
        }
        else {
            health -= damage_percent;
            health_bar.transform.localScale -= new Vector3(0, damage_percent, 0);
        }
    }
}
