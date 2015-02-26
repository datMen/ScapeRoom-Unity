using UnityEngine;
using System.Collections;

public class Camera_trigger : MonoBehaviour {
    
    [SerializeField]
    private GameObject GO_cam_intelligence;
    private Camera_inteligence cam_intelligence;

    void Start() {
        cam_intelligence = GO_cam_intelligence.GetComponent<Camera_inteligence>();
    }

    void OnTriggerStay(){
        cam_intelligence.startFollowPlayer();
    }

    void OnTriggerExit() {
        cam_intelligence.stopFollowPlayer();
    }
}
