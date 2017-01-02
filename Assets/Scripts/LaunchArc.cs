using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaunchArc : MonoBehaviour {

	public Image launchArc;
	public Image launchArrow;
	public Camera cam;

	//Arrow orbit variables
	public Transform center;
	Vector3 axis = Vector3.up;
	float radius = 2.0f;
	float radiusSpeed = 0.5f;
	float rotationSpeed = 80.0f;

	float OFFSETSCALE = 2;

	//launch arc constructor
	public LaunchArc( ref Image arc) {
		launchArc = arc;
	}

	//launch arrow constructor
	public void LaunchArrow( ref Image arrow) {
		launchArrow = arrow;
	}

	//Method for moving the arc to the ship
	public void ChangeArcPos(Vector3 pos) {

		launchArc.transform.position = pos;
	}

	//method for orbitting the arrow
	public void Orbit(Vector3 shipPos) {
		
		transform.RotateAround (center.position, axis, rotationSpeed * Time.deltaTime);
		//desiredPosition = (transform.position - center.position).normalized * radius + center.position;
		launchArrow.transform.position = Vector3.MoveTowards(transform.position, shipPos, Time.deltaTime * radiusSpeed);
	}

	public void SetCamera(ref Camera in_cam) {

		cam = in_cam;
	}

	public void CalculateOffset(Vector3 shipPos, Vector3 mousePos) {

		float theta = (mousePos.y - shipPos.y) / (mousePos.x - shipPos.x);

		float xOffset;
		float yOffset;

		//case when we don't have to flip the offset vs when we have to
		if (mousePos.x > shipPos.x) {
			 xOffset = shipPos.x + OFFSETSCALE * Mathf.Cos (theta);
			 yOffset = shipPos.y + OFFSETSCALE * Mathf.Sin (theta);
		} else {
			 xOffset = shipPos.x - OFFSETSCALE * Mathf.Cos (theta);
			 yOffset = shipPos.y - OFFSETSCALE * Mathf.Sin (theta);
		}

		Vector3 offsetPos= new Vector3 (xOffset, yOffset, 0);

		launchArc.transform.position = offsetPos;
	}
		
}
