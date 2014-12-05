using UnityEngine;
using System.Collections;

public class Puerta : MonoBehaviour {

	private Inventario inventario;
	// door_status:
	// 		0 = Closed
	// 		1 = Opening
	// 		2 = Opened
	// 		3 = Closing
	private int door_status = 0;
	
	void Start() {
		// Get player GameObject & assign his "Inventario" script to local variable "inventory"
		GameObject player = GameObject.Find("Player") as GameObject;
		inventario = player.GetComponent<Inventario> ();
	}

	void Update () {
		// if player has the key and door is closed
		if (inventario.getKey() && door_status != 0) {
			// if the door is about to be opened
			if (door_status == 1) {
				// if close door animation is not running
				if (!animation.IsPlaying("animCerrarPuerta")) {
					// Open door
					animation.Play("animAbrirPuerta");
					// Door opened
					door_status = 2;
				}
			}
			// if the door is about to be closed
			else if (door_status == 3) {
				// if open door animation is not running
				if (!animation.IsPlaying("animAbrirPuerta")) {
					// Close door
					animation.Play("animCerrarPuerta");
					// Door closed
					door_status = 0;
				}
			}
		}
	}

	// Turn door to opening status when the player join the collider
	void OnTriggerEnter(Collider collider) {
		if (inventario.getKey()) {
			door_status = 1;
		}
	}

	// Turn door to close status when the player leaves the collider
	void OnTriggerExit(Collider collider) {
		if (inventario.getKey()) {
			door_status = 3;
		}
	}

}
