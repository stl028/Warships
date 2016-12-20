using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControls : MonoBehaviour {
	
	public GameObject clickedGameObj;

	public void SelectedShip(string clickedOn)
	{
		clickedGameObj = GameObject.Find(clickedOn);
		//Turn();

	}
	/*
	public void Turn()
	{
		//Vector3 mouseScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);
		Vector3 mouseScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z);

		Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

		transform.LookAt(mouseWorldPosition, Vector3.right);
	}*/

	public void Turn() {
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 5.23f;

		Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);
		mousePos.x = mousePos.x - objectPos.x;
		mousePos.y = mousePos.y - objectPos.y;

		float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
	}

	//will retun the angle
	public int ConeAngle(Vector3 shipPos, Vector2 mousePos) {

	}


}
