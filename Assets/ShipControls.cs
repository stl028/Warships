using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControls : MonoBehaviour {

    bool directionOn = false;

	public GameObject clickedObj;
    public ClickControl control0;
    public ClickControl control1;

	// Use this for initialization
	void Start () {

        control0 = GameObject.Find("ship0").GetComponent<ClickControl>();
        control1 = GameObject.Find("ship1").GetComponent<ClickControl>(); 
	}

    void Update()
    {   
		/*
		if (Input.GetMouseButtonDown(0))
        {
            directionOn = true;
			clickedObj = GetClickedGameObject ();
        }
        if (Input.GetMouseButtonDown(1))
        {
            directionOn = false;
        }

        if (directionOn == true)
        {
            control0.SelectedShip(this.transform.gameObject);
            control1.SelectedShip(this.transform.gameObject);
        }
		if (ship0.

*/

		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hitInfo = new RaycastHit();
			bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
			if (hit) 
			{
				Debug.Log("Hit " + hitInfo.transform.gameObject.name);
				var name = hitInfo.gameObject.name;

				if (hitInfo.transform.gameObject.tag == "ship0")
				{
					control0.SelectedShip(this.transform.gameObject);
				} else {
					control1.SelectedShip(this.transform.gameObject);
				}
			} else {
				Debug.Log("No hit");
			}
			Debug.Log("Mouse is down");
		} 
    }
	
	
}
