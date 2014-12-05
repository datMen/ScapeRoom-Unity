using UnityEngine;
using System.Collections;

public class Inventario : MonoBehaviour {
	private bool key;
	
	// Returns "key" variable
	public bool getKey() {
		return key;
		
	}

	// Set "key" variable
	public void setKey(bool val) {
		key = val;
	}
}
