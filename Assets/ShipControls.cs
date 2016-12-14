using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControls : MonoBehaviour {

    public ClickControl control;

	// Use this for initialization
	void Start () {
        control = GameObject.Find("ship0").GetComponent<ClickControl>();
	}

    void OnMouseDown()
    {
        control.SelectedShip(this.transform.gameObject);
    }
	
	
}
