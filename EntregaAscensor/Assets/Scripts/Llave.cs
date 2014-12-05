using UnityEngine;
using System.Collections;

public class Llave : MonoBehaviour 
{
	private Inventario inventory;
	
	void Start() {
		// Get player GameObject & assign his "Inventario" script to local variable "inventory"
		GameObject player = GameObject.Find("Player") as GameObject;
		inventory = player.GetComponent<Inventario> ();
	}
	

	// Set inventory key = true when player joins the collider zone and destroy key GameObject
	void OnTriggerEnter(Collider collider) {
		inventory.setKey(true);
		Destroy(gameObject);
	}
	
}
