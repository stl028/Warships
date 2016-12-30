using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(BoxCollider2D))]
public class ShipPhysics : MonoBehaviour
{

	string currentlyMoving = "";

	void OnTriggerEnter2D(Collider2D col) {
        Debug.Log("Collided!");
		Debug.Log("MovingShip:" + currentlyMoving);

		if (col.gameObject.tag == "Ship" && !currentlyMoving.Equals(""))
        {
            Debug.Log("Name of ship: " + col.gameObject.name);
            GameObject hitShip = GameObject.Find(col.gameObject.name);
            Destroy(hitShip);
        }
	}

	public void SetCurrent(string name) {
		currentlyMoving = name;
	}

    /*void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collided!");
        if (col.gameObject.tag == "Ship")
        {
            Destroy(col.gameObject);
        }
    }*/

    /*void OnTriggerEnter(Collider col)
    {
        Debug.Log("Collided!");
        if (col.gameObject.tag == "Ship")
        {
            Destroy(col.gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Collided!");
        if (col.gameObject.tag == "Ship")
        {
            Destroy(col.gameObject);
        }
    }
    */

}
