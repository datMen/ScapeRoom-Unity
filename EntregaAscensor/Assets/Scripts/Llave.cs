using UnityEngine;
using System.Collections;

public class Llave : MonoBehaviour 
{
	private Inventario inventario;
	
	void Start()
	{
		GameObject player = GameObject.Find("Player") as GameObject;
		inventario = player.GetComponent<Inventario> ();
	}
	
	
	void OnTriggerEnter(Collider collider)
	{
		inventario.setLlave(true);
		Destroy (gameObject);
	}
	
}
