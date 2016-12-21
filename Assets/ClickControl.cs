using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ClickControl : MonoBehaviour {
    
	ShipControls control;
	public Camera cam;
    Thread dirThread;

    //For now the cone width of all ships is 30
    float coneWidth = Mathf.PI / 6;

    float tempDirection = 0;

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

        else if (Input.GetMouseButtonDown(0) && leftClick == 1)
        {
            Debug.Log("LeftClick1");
            leftClick++;

            Vector3 shipPos = control.GetShipPosition();
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            float theta = ConeDirection(shipPos, mousePos);
            float coneStart = theta - coneWidth / 2;
            float coneEnd = theta + coneWidth / 2;

            tempDirection = theta;
            float spacing = Mathf.PI / 180;

            dirThread = new Thread(() => startDirectionCounter(spacing, coneStart, coneEnd));
            dirThread.Start();

        }

        else if (Input.GetMouseButtonDown(0) && leftClick == 2)
        {
            ++leftClick;
            Debug.Log("Final Float:" + tempDirection.ToString());
            dirThread.Abort();
        }

        if (Input.GetMouseButtonDown(1) && leftClick != 0)
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

    public void startDirectionCounter(float spacing, float coneStart, float coneEnd)
    {

        bool direction = false;

        while (leftClick == 2)
        {
            Debug.Log("in inf loop");
            Debug.Log(leftClick.ToString());


            if (tempDirection + spacing < coneEnd && !direction)
            {
                tempDirection += spacing;
            }
            else if (tempDirection + spacing > coneEnd && !direction)
            {
                tempDirection -= spacing;
                direction = true;
            }
            else if (tempDirection - spacing > coneStart && direction)
            {
                tempDirection -= spacing;
            }
            else if (tempDirection - spacing < coneStart && direction)
            {
                tempDirection += spacing;
                direction = false;
            }
            /*
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("breakLeftClick");
                leftClick++;
                //break;
            }
            else if (Input.GetMouseButtonDown(1) && leftClick == 2)
            {
                Debug.Log("breakRightClick");
                break;
            }
            */
            Debug.Log("bot of inf loop");
        }
    }
}
