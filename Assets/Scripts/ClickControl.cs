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

    //the angle the user clicked
    float tempDirection = 0;

    //maximum width of the power bar
    float fullWidth = 256;

    //stores the current set power
    float finalPower;

    //to start and stop addition/subtraction to power
    bool powerInc = false;

    bool powerDec = false;

    //speed  to increment the power bar
    float barSpeed = 25;

    //For figuring out which click state we're in
    int leftClick = 0;


    float barDisplay = 0;
    Vector2 pos = new Vector2(20,40);
    Vector2 size = new Vector2(60,20);
    Texture2D progressBarEmpty;
    Texture2D progressBarFull;

    void OnGUI()
    {

        // draw the background:
        GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
        Rect rectEmpty = new Rect(0, 0, size.x, size.y);
        GUI.Box(rectEmpty, progressBarEmpty);

        // draw the filled-in part:
        GUI.BeginGroup(new Rect(0, 0, size.x * finalPower, size.y));
        Rect rectFull = new Rect(0, 0, size.x, size.y);
        GUI.Box(rectFull, progressBarFull);
        GUI.EndGroup();

        GUI.EndGroup();

    }

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
                control.SelectedShip(hitInfo.collider.gameObject);

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
            float theta = ConeDirection(mousePos, shipPos);
            float coneStart = theta - coneWidth / 2;
            float coneEnd = theta + coneWidth / 2;

            tempDirection = theta;
            float spacing = Mathf.PI / 180;

            dirThread = new Thread(() => startDirectionCounter(spacing, coneStart, coneEnd));
            dirThread.Start();

        }

        ////////////////////////////////////For selection power///////////////////////////
        else if (Input.GetMouseButtonDown(0) && leftClick == 2)
        {
            dirThread.Abort();
            leftClick++;
            powerInc = true;
        }

        //On the last click, we get the final power and move the ship
        else if (Input.GetMouseButtonDown(0) && leftClick == 3)
        {
            leftClick = 0;
            Debug.Log("Power:" + finalPower.ToString());
            Debug.Log("Angle:" + tempDirection.ToString());
            powerInc = false;
            powerDec = false;


            moveShip();
            finalPower = 0;
        }

        if (powerInc)
        {
            finalPower += Time.deltaTime * barSpeed;

            //stops the power bar from going past its max length
            finalPower = Mathf.Clamp(finalPower, 0, fullWidth);

            //start decreasing power when the power reaches the maximum
            if (finalPower == fullWidth)
            {
                powerInc = false;
                powerDec = true;
            }

            //set the width of the GUI Texture equal to that power value
            //GUITexture bar = GameObject.Find("powerBar").GetComponent<GUITexture>();
           
        }

        if (powerDec)
        {
            finalPower -= Time.deltaTime * barSpeed;

            //stops the power bar from goin past 0
            finalPower = Mathf.Clamp(finalPower, 0, fullWidth);

            //starts increasing power when the power reaches 0
            if (finalPower == 0)
            {
                powerInc = true;
                powerDec = false;
            }
        }


        ////////////////////////////////////For right clicking/////////////////////////////

        if (Input.GetMouseButtonDown(1) && leftClick != 0)
        {

            leftClick--;
            powerInc = false;
            powerDec = false;
            finalPower = 0;
        }

    }//update bracket

    //Method to get the direction of the cone
    public float ConeDirection(Vector2 mousePos, Vector3 shipPos)
    {
        //use the slope formula from grade schoool
        float slope = (mousePos.y - shipPos.y) / (mousePos.x - shipPos.x);

        
        float angle = Mathf.Atan(slope);

        //check to see if we are going left, if so we need to offset by pi
        if (mousePos.x < shipPos.x) angle += Mathf.PI;

        return angle;
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
            Debug.Log("bot of inf loop");
        }
    }

    public void moveShip()
    {
        Vector3 shipPos = control.GetShipPosition();
        finalPower /= 20;
        float temp = finalPower * Mathf.Cos(tempDirection);
        Debug.Log("X offset: " + temp);
        shipPos.x += (finalPower * Mathf.Cos(tempDirection));
        shipPos.y += (finalPower * Mathf.Sin(tempDirection));
        Debug.Log("X coors: " + shipPos.x);
        Debug.Log("Y coor: " + shipPos.y);
        //Debug.Log("Control ship: " + control.clickedGameObj.transform.name);
        control.SetShipPosition(shipPos);
    }
}
