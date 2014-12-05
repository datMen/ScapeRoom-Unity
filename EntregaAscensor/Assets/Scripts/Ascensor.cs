using UnityEngine;
using System.Collections;

public class Ascensor : MonoBehaviour {
	private PuertaAscensor1 door1;
	private PuertaAscensor2 door2;
	
	void Start()
	{
		GameObject door1_obj = GameObject.Find("PuertaAscensorPiso1Contenedor") as GameObject;
		door1 = door1_obj.GetComponent<PuertaAscensor1>();

		GameObject door2_obj = GameObject.Find("PuertaAscensorPiso2Contenedor") as GameObject;
		door2 = door2_obj.GetComponent<PuertaAscensor2>();
	}

	public void openDoor1() {
		door1.animation.Play("animAbrirPuertaAscensor");
	}

	public void closeDoor1() {
		door1.animation.Play("animCerrarPuertaAscensor");
	}

	public void openDoor2() {
		door2.animation.Play("animAbrirPuertaAscensor");
	}

	public void closeDoor2() {
		door2.animation.Play("animCerrarPuertaAscensor");
	}
}
