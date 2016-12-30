using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(BoxCollider2D))]
public class ShipPhysics : MonoBehaviour
{
	//The currently selected ship
	string currentlyMoving = "";

	void OnTriggerEnter2D(Collider2D col) {
        Debug.Log("Collided!");
		Debug.Log("MovingShip:" + currentlyMoving);

		//Destroy the ship that collides with the moving ship
		if (col.gameObject.tag == "Ship" && !currentlyMoving.Equals(""))
        {
            Debug.Log("Name of ship: " + col.gameObject.name);
            GameObject hitShip = GameObject.Find(col.gameObject.name);
            Destroy(hitShip);
        }
	}

	//sets the currently moving ship
	public void SetCurrent(GameObject obj) {
		currentlyMoving = obj.name;
	}
		
}
