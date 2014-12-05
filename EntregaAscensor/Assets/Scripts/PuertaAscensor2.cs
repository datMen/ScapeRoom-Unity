using UnityEngine;
using System.Collections;

public class PuertaAscensor2 : MonoBehaviour {

	// Close door on TriggerExit event
	void OnTriggerExit(Collider collider) {
		animation.Play("animCerrarPuertaAscensor");
	}
}
