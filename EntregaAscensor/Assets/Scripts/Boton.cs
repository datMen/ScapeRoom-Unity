using UnityEngine;
using System.Collections;

public class Boton : MonoBehaviour {

	// button_status:
	// 		0 = Not Started
	// 		1 = Opening
	// 		2 = Closing
	// 		3 = Finished
	private int button_status = 0;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (button_status == 1) {
			if (!animation.IsPlaying("animPresionarBoton")) {
				animation.Play("animSoltarBoton");
				button_status = 2;
			}
		}
		else if (button_status == 2) {
			if (!animation.IsPlaying("animPresionarBoton") && !animation.IsPlaying("animSoltarBoton")) {
				button_status = 3;
			}
		}
	}
	
	void OnTriggerEnter(Collider collider)
	{
		animation.Play("animPresionarBoton");
		button_status = 1;
	}
}
