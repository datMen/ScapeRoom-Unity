using UnityEngine;
using System.Collections;

public class Ascensor : MonoBehaviour {
	private PuertaAscensor1 door1;
	private PuertaAscensor2 door2;
	
	void Start() {
		// Get door1 GameObject & assign his script to local variable "door1"
		GameObject door1_obj = GameObject.Find("PuertaAscensorPiso1Contenedor") as GameObject;
		door1 = door1_obj.GetComponent<PuertaAscensor1>();

		// Get door2 GameObject & assign his script to local variable "door2"
		GameObject door2_obj = GameObject.Find("PuertaAscensorPiso2Contenedor") as GameObject;
		door2 = door2_obj.GetComponent<PuertaAscensor2>();
	}

	// Run Door1 open animation
	public void openDoor1() {
		door1.animation.Play("animAbrirPuertaAscensor");
	}

	// Run Door1 close animation
	public void closeDoor1() {
		door1.animation.Play("animCerrarPuertaAscensor");
	}

	// Run Door2 open animation
	public void openDoor2() {
		door2.animation.Play("animAbrirPuertaAscensor");
	}

	// Run Door2 close animation
	public void closeDoor2() {
		door2.animation.Play("animCerrarPuertaAscensor");
	}
}
