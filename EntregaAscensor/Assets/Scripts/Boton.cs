using UnityEngine;
using System.Collections;

public class Boton : MonoBehaviour {
	private Ascensor elevator;

	void Start() {
		// Get elevator GameObject & assign his script to local variable "elevator"
		GameObject elevator_obj = GameObject.Find("AscensorContenedor") as GameObject;
		elevator = elevator_obj.GetComponent<Ascensor>();
	}
	
	// Press button when player enters the collider zone
	void OnTriggerEnter(Collider collider) {
		if (!animation.IsPlaying("animSoltarBoton") && !elevator.animation.IsPlaying("animSubirAscensor")) {
			animation.Play("animPresionarBoton");
		}
	}

	// Start the "button return" animation, returns the button to default position
	public void buttonReset() {
		animation.Play("animSoltarBoton");
	}

	// Move elevator down
	public void elevatorDown() {
		elevator.animation.Play("animBajarAscensor");
	}

	// Move elevator up
	public void elevatorUp() {
		elevator.animation.Play("animSubirAscensor");
	}
}
