using UnityEngine;
using System.Collections;

public class EnemyNav : MonoBehaviour {
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Transform nav_floor;

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
        return Vector3.Distance(transform.position, target.position);
    }

    // 
    void setRandomWayPoint() {
        target.position = new Vector3(Random.Range(-nav_floor_size.x, nav_floor_size.x), target.position.y, Random.Range(-nav_floor_size.z, nav_floor_size.z));
        agent.SetDestination(target.position);
    }
}
