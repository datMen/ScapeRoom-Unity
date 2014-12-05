using UnityEngine;
using System.Collections;

public class Teletransporte : MonoBehaviour {

	private GameObject player;
	
	void Start() {
		// Get player GameObject & assign it to local variable "player"
		player = GameObject.Find("Player") as GameObject;
	}

	// Teleport player to one floor below
	void OnTriggerEnter(Collider collider) {
		player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y-4, player.transform.position.z);
	}
}
