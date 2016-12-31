using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaunchArc : MonoBehaviour {

	public Image launchArc;
	public Image launchArrow;

	public void ChangeArcPos(Vector3 pos) {

		launchArc.transform.position = pos;
	}

	public void ChangeArrPos(Vector3 pos) {

	}

	public LaunchArc( ref Image arc) {
		launchArc = arc;
	}

	public void LaunchArrow( ref Image arrow) {
		launchArrow = arrow;
	}

}
