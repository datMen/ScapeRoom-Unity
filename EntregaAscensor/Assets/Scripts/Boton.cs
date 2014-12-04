using UnityEngine;
using System.Collections;

public class Boton : MonoBehaviour {
	private Ascensor elevator;

	void Start()
	{
		GameObject elevator_obj = GameObject.Find("AscensorContenedor") as GameObject;
		elevator = elevator_obj.GetComponent<Ascensor>();
	}
	
	// Update is called once per frame
	
	void OnTriggerEnter(Collider collider)
	{
		animation.Play("animPresionarBoton");
	}

	public void buttonReset() {
		animation.Play("animSoltarBoton");
	}

	public void elevatorDown() {
		elevator.animation.Play("animBajarAscensor");
	}

	public void elevatorUp() {
		elevator.animation.Play("animSubirAscensor");
	}
}
