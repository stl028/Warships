using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControls : MonoBehaviour {
	
	public GameObject clickedGameObj;

	public void SelectedShip(GameObject clickedOn)
	{
        clickedGameObj = clickedOn;
	}
	

	public void Turn() {
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 5.23f;

		Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);
		mousePos.x = mousePos.x - objectPos.x;
		mousePos.y = mousePos.y - objectPos.y;

		float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
	}

    public Vector3 GetShipPosition()
    {
        return clickedGameObj.transform.position;
    }

    public void SetShipPosition(Vector3 shipPos, float speed)
    {
        clickedGameObj.transform.position = Vector3.Lerp(clickedGameObj.transform.position, shipPos, speed) ;
    }



}
