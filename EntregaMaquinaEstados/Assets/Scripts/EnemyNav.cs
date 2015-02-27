using UnityEngine;
using System.Collections;

public class EnemyNav : MonoBehaviour {
    [SerializeField]
    private Transform enemy_target;

    [SerializeField]
    private Transform nav_floor;

    [SerializeField]
    private Transform player;

    private Vector3 nav_floor_size;
    private NavMeshAgent agent;
    float taget_max_distance = 2.5F;

    void Start () {
        agent = GetComponent<NavMeshAgent>();
        nav_floor_size = nav_floor.transform.localScale*5;
        setRandomWayPoint();
    }
    
    void Update () {
        if (getWayPointDistance() < taget_max_distance) { // Agent is too close to the waypoint
           setRandomWayPoint();
        }
    }

    float getWayPointDistance() {
        return Vector3.Distance(transform.position, enemy_target.position);
    }

    // Update WayPoint position randomly
    void setRandomWayPoint() {
        enemy_target.position = new Vector3(Random.Range(-nav_floor_size.x, nav_floor_size.x), enemy_target.position.y, Random.Range(-nav_floor_size.z, nav_floor_size.z));
        agent.SetDestination(enemy_target.position);
    }

    public void startFollowPlayer() {
        agent.SetDestination(player.position);
    }

    public void stopFollowPlayer() {
        agent.SetDestination(enemy_target.position);
    }
}
