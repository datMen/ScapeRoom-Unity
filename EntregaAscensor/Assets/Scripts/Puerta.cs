using UnityEngine;
using System.Collections;

public class Puerta : MonoBehaviour {

	private Inventario inventario;
	private bool opening;
	private bool close;
	
	void Start()
	{
		GameObject player = GameObject.Find("Player") as GameObject;
		inventario = player.GetComponent<Inventario> ();
	}

	void Update ()
	{
		if (inventario.getLlave()) {
			if (opening) {
				if (!close && !animation.IsPlaying("animCerrarPuerta")) {
					animation.Play("animAbrirPuerta");
					opening = false;
				}
			}
			else if (close && !opening) {
				if (!animation.IsPlaying("animAbrirPuerta")) {
					animation.Play("animCerrarPuerta");
					close = false;
				}
			}
		}
	}
	
	void OnTriggerEnter(Collider collider)
	{
		if (inventario.getLlave()) {
			opening = true;
			close = false;
		}
	}

	void OnTriggerExit(Collider collider)
	{
		if (inventario.getLlave()) {
			close = true;
		}
	}

}
