using UnityEngine;
using System.Collections;

public class Camera_inteligence : MonoBehaviour {
    [SerializeField]
    private GameObject player;
    private Quaternion start_rotation;
    private Vector3 start_position;
    private float quat_time;

    void Start() {
        start_rotation = transform.rotation;
        start_position = transform.position;
    }

	public void startFollowPlayer() {
        quat_time = Time.deltaTime * 5.0f;
        animation.Stop("animCamera");
        Vector3 targetPoint = new Vector3(player.transform.position.x, player.transform.position.y+2, player.transform.position.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetPoint - transform.position), quat_time);
    }

    public void stopFollowPlayer() {
        transform.position = Vector3.Lerp(transform.position, start_position, quat_time);
        transform.rotation = Quaternion.Slerp(transform.rotation, start_rotation, quat_time);
        //yield return new WaitForSeconds(quat_time);
        //animation.Play("animCamera");
    }
}
