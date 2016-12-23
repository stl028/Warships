using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickControl : MonoBehaviour {
    
	ShipControls control;
	public Camera cam;


	//For figuring out which state we're in
	int leftClick = 0;
	int rightClick = 0;

	void Start() {

	}

	void Update() {

		//turning the ship
		if (leftClick == 1 && rightClick == 1) {

			control.Turn ();
		}

		//For checking if a ship is clicked
		if (Input.GetMouseButtonDown(0))
		{
			//RaycastHit hitInfo = new RaycastHit();
			//bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

			Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
			//Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);

			RaycastHit2D hitInfo = Physics2D.Raycast (mousePosition, Vector2.zero);

			if (hitInfo.collider != null) 
			{
				Debug.Log ("Hit");
				//string name = hitInfo.transform.gameObject.name;
				string name = hitInfo.collider.gameObject.name;
				Debug.Log ("Name is: " + name);
				//Debug.Log("Hit " + hitInfo.transform.gameObject.name);
				control = GameObject.Find(name).GetComponent<ShipControls>();
				control.SelectedShip(this.transform.gameObject.name);

				leftClick++;
				rightClick++;

			} else {
				Debug.Log("No hit");
			}
		} //if bracket

		if (Input.GetMouseButtonDown (1) && rightClick != 0) {

			leftClick--;
			rightClick--;
		}

	}//update bracket


}
