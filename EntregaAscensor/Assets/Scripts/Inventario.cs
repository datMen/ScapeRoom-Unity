using UnityEngine;
using System.Collections;

public class Inventario : MonoBehaviour {
	
	
	private bool llave;
	
	
	public bool getLlave()
	{
		return llave;
		
	}
	
	public void setLlave(bool val)
	{
		llave = val;
		Debug.Log ("Tiene llave: "+llave);
	}
}
