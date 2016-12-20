using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickControl : MonoBehaviour {
    
	ShipControls control;
	public Camera cam;


	//For figuring out which state we're in
	int leftClick = 0;
	void Start() {

	}

    void Update()
    {

        //turning the ship
        if (leftClick == 1)
        {

            control.Turn();
        }


        ///////////////////////////////////////For rotating the ship////////////////////////////////////////

        if (Input.GetMouseButtonDown(0) && leftClick == 0)
        {
            //RaycastHit hitInfo = new RaycastHit();
            //bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

            Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hitInfo = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hitInfo.collider != null)
            {
                Debug.Log("hit");

                string name = hitInfo.collider.gameObject.name;
                control = GameObject.Find(name).GetComponent<ShipControls>();
                control.SelectedShip(this.transform.gameObject.name);

                leftClick++;

            }
            else
            {
                Debug.Log("No hit");
            }
        } //if bracket

        ///////////////////////////////////For Selecting the direction/////////////////////////////////////

        if (Input.GetMouseButtonDown(0) && leftClick == 1)
        {
            Vector3 shipPos = control.GetShipPosition();
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            float theta = ConeDirection(shipPos, mousePos);


        }

        if (Input.GetMouseButtonDown(1))
        {

            leftClick--;
        }

    }//update bracket

    //Method to get the direction of the cone
    public float ConeDirection(Vector2 mousePos, Vector3 shipPos)
    {
        float slope = (mousePos.y - shipPos.y) / (mousePos.x - shipPos.x);

        return Mathf.Atan(slope);
    }
}
