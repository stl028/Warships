using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickControl : MonoBehaviour {
    public GameObject clickedGameObj;

	public void SelectedShip(GameObject clickedOn)
    {
        clickedGameObj = clickedOn;
        print(clickedGameObj.name);
        Update();

    }

    void Update()
    {
        Vector3 mouseScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);

        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

        transform.LookAt(mouseWorldPosition, Vector3.right);
    }
}
