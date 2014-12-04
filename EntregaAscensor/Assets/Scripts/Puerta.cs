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
	
	void Start()
	{
		GameObject player = GameObject.Find("Player") as GameObject;
		inventario = player.GetComponent<Inventario> ();
	}

	void Update ()
	{
			
		if (inventario.getLlave()) { // Player has the key
			if (door_status == 1) { // Door is about to be opened
				if (!animation.IsPlaying("animCerrarPuerta")) {
					animation.Play("animAbrirPuerta"); // Opening door
					door_status = 2; // Door opened
				}
			}
			else if (door_status == 3) { // Door is about to be closed
				if (!animation.IsPlaying("animAbrirPuerta")) {
					animation.Play("animCerrarPuerta"); // Closing door
					door_status = 0; // Door closed
				}
			}
		}
	}
	
	void OnTriggerEnter(Collider collider)
	{
		if (inventario.getLlave()) {
			door_status = 1;
		}
	}

	void OnTriggerExit(Collider collider)
	{
		if (inventario.getLlave()) {
			door_status = 3;
		}
	}

}
