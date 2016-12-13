using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {
	
	//Vars with general information
	int hp;
	int posX;
	int posY;
	
	//Vars detailing movement
	int coneWidth;
	double arrowSpeed;
	double power;

	public Ship()
    {

    }

	void SetParams(int health, int xCoor, int yCoor, int cWidth, double aSpeed, double str) {
		hp = health;
		posX = xCoor;
		posY = yCoor;
		coneWidth = cWidth;
		arrowSpeed = aSpeed;
		power = str;
	}

	void updatePos(int xCoor, int yCoor) {
		posX = xCoor;
		posY = yCoor;
	}

	void updateHP(int health) {
		hp = health;
	}
}
