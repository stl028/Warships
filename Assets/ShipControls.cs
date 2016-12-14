using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControls : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		/*
		float xInput = (Input.GetAxis ("Mouse X"))*-5;
		float yInput = (Input.GetAxis ("Mouse Y"))*-5;
		Vector3 facing = new Vector3 (0, 0 , xInput);
		Vector3 turning = new Vector3 (0, 0, yInput);
		transform.Rotate (facing);
		transform.Rotate (turning);
		//rotate (facing);*/
		Vector3 mouseScreenPosition = new Vector3( Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z );

	    Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint( mouseScreenPosition );

		transform.LookAt( mouseWorldPosition, Vector3.right );  

			 
	}

	void rotate(Vector3 rotation) {
		//transform.Rotate(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
		transform.Rotate(rotation);
	}
	/*
	void OnMouseDown() {
		transform.Rotate(Input.GetAxis("Mouse Y")*2.0F, Input.GetAxis("Mouse X")*2.0F, 0);
	}
	*/	
}
