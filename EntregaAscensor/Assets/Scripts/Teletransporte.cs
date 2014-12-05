using UnityEngine;
using System.Collections;

public class Teletransporte : MonoBehaviour {

	private GameObject player;
	
	void Start()
	{
		player = GameObject.Find("Player") as GameObject;
	}
	
	
	void OnTriggerEnter(Collider collider)
	{
		player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y-4, player.transform.position.z);
	}
}
