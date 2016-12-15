using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControls : MonoBehaviour {

    bool directionOn = false;

    public ClickControl control0;
    public ClickControl control1;

	// Use this for initialization
	void Start () {
        control0 = GameObject.Find("ship0").GetComponent<ClickControl>();
        control1 = GameObject.Find("ship1").GetComponent<ClickControl>(); 
	}

    void Update()
    {   if (Input.GetMouseButtonDown(0))
        {
            directionOn = true;
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
    }
	
	
}
